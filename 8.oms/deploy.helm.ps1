helm install stable/msoms --name omsagent `
    --set omsagent.secret.wsid=<your_workspace_id> `
    --set omsagent.secret.key=<your_workspace_key>