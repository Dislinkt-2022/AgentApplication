terraform {
  backend "pg" {
  }
}

provider "heroku" {
}

variable "agent_app_api_name" {
  description = "Agent Application Web API"
}

variable "agent_app_client_name" {
  description = "Agent Application frontend"
}

resource "heroku_config" "agent_app_api" {
  vars = {
    CORS_ORIGIN = "https://${heroku_app.agent_app_client.name}.herokuapp.com"
  }
}

resource "heroku_app" "agent_app_api" {
  name   = var.agent_app_api_name
  region = "eu"
  stack  = "container"
}

resource "heroku_build" "agent_app_api" {
  app_id = heroku_app.agent_app_api.id

  source {
    path = "agent_app_api"
  }
}

resource "heroku_app_config_association" "agent_app_api" {
  app_id = heroku_app.agent_app_api.id

  vars = heroku_config.agent_app_api.vars
}

resource "heroku_addon" "database" {
  app_id  = heroku_app.agent_app_api.id
  plan = "heroku-postgresql:hobby-dev"
}

#resource "heroku_config" "agent_app_client" {
#  vars = {
#    API_URL = "${heroku_app.agent_app_api.name}.herokuapp.com"
#  }
#}

resource "heroku_app" "agent_app_client" {
  name   = var.agent_app_client_name
  region = "eu"
  stack  = "container"
}

#resource "heroku_app_config_association" "agent_app_client" {
#  app_id = heroku_app.agent_app_client.id
#
#  vars = heroku_config.agent_app_client.vars
#}
#
#resource "heroku_build" "agent_app_client" {
#  app_id = heroku_app.agent_app_client.id
#
#  source {
#    path = "agent_app_client"
#  }
#  depends_on = [
#    null_resource.agent_app_client_build
#  ]
#}
#
#data "template_file" "agent_app_client_build" {
#  template = file("${path.module}/agent_app_client/heroku.tpl")
#  vars = {
#    api_url = "\\\"https://${heroku_app.agent_app_api.name}.herokuapp.com/api/\\\""
#  }
#}
#
#resource "null_resource" "agent_app_client_build" {
#  triggers = {
#    template = data.template_file.agent_app_client_build.rendered
#  }
#
#  provisioner "local-exec" {
#    command = "echo \"${data.template_file.agent_app_client_build.rendered}\" > ${path.module}/agent_app_client/heroku.yml"
#  }
#}

output "agent_app_api_url" {
  value = "https://${heroku_app.agent_app_api.name}.herokuapp.com"
}
output "agent_app_client_url" {
  value = "https://${heroku_app.agent_app_client.name}.herokuapp.com"
}