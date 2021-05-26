# Automated setup

CURR_DIR:=$(shell pwd)

all: start-containers sleep setup-database

start-containers:
	docker-compose --project-name utmapp up -d --build

setup-database:
	docker run -it --rm \
        --name utmapp-tmp-setup-env \
        --link utmapp-db:utmapp-tmp-setup-env \
        --net utmapp_utmapp-network \
        -v $(CURR_DIR)/UTMAPP:/app \
        -w /app \
        --env-file ./.env \
        microsoft/dotnet:sdk \
        dotnet ef database update

sleep:
	echo "Sleeping 10 seconds..."
	sleep 10

stop-containers:
	docker-compose --project-name utmapp down

re: stop-containers start-containers
