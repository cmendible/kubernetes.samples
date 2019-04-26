using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace pod.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PodsController : ControllerBase
    {
        private bool useKubeConfig = false;

        public PodsController(IConfiguration config)
        {
            this.useKubeConfig = bool.Parse(config["UseKubeConfig"]);
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IDictionary<string, IEnumerable<string>>> GetPods()
        {
            // Load from the default kubeconfig on the machine.
            KubernetesClientConfiguration config = null;
            if (!useKubeConfig)
            {
                config = KubernetesClientConfiguration.InClusterConfig();
            }
            else
            {
                config = KubernetesClientConfiguration.BuildConfigFromConfigFile();
            }

            // Use the config object to create a client.
            var client = new Kubernetes(config);
            var namespaces = client.ListNamespace();
            var result = new Dictionary<string, IEnumerable<string>>();
            foreach (var ns in namespaces.Items)
            {
                Console.WriteLine(ns.Metadata.Name);

                var pods = new List<string>();
                var list = client.ListNamespacedPod(ns.Metadata.Name);
                foreach (var item in list.Items)
                {
                    pods.Add(item.Metadata.Name);
                }

                result.Add(ns.Metadata.Name, pods);
            }

            return result;
        }
    }
}
