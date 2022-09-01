#!/bin/sh

cd terraform || exit
DATABASE_URL=$(heroku config:get DATABASE_URL --app "$TERRAFORM_BACKEND") && export DATABASE_URL
terraform init -backend-config="conn_str=$DATABASE_URL"
terraform apply -auto-approve -var agent_app_api_name="$APP_NAME" -var agent_app_client_name="${GATEWAY_NAME}"