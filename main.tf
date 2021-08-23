terraform {
  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
    }
  }
}

provider "azurerm" {
  features {}
}


resource "azurerm_resource_group" "exchange-rg" {
  name     = "indgexchange-tf"
  location = "westus2"
}

resource "azurerm_app_service_plan" "exchange-sp" {
  name                = "indgexchange-appserviceplan"
  location            = azurerm_resource_group.exchange-rg.location
  resource_group_name = azurerm_resource_group.exchange-rg.name

  sku {
    tier = "Free"
    size = "F0"
  }
}

resource "azurerm_app_service" "indgexchange_api" {
  name                = "indgexchange-appservice"
  location            = azurerm_resource_group.exchange-rg.location
  resource_group_name = azurerm_resource_group.exchange-rg.name
  app_service_plan_id = azurerm_app_service_plan.exchange-sp.id


}

output "app_service_name_itemtrader_api" {
  value = azurerm_app_service.indgexchange_api.name
}

output "app_service_default_hostname_itemtrader_api" {
  value = "https://${azurerm_app_service.indgexchange_api.default_site_hostname}"
}




