#!/bin/sh
#!/usr/bin/env bash
which sh
cd ..
docker exec $(docker ps -q -f name=$DOCKER_POSTGRES_DB_CONTAINER_NAME) pg_dump -U $POSTGRES_USER $POSTGRES_DB_NAME > $POSTGRES_DB_DATA_DIR/backups/$POSTGRES_DB_NAME/"dump_$(date +"%F %T").sql"