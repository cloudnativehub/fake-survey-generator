@description('Name of the Log Analytics Workspace resource')
param name string

@description('Location of the Log Analytics Workspace resource')
param location string = resourceGroup().location

resource logAnalytics 'Microsoft.OperationalInsights/workspaces@2021-12-01-preview' = {
  name: name
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
  }
}

output name string = logAnalytics.name
