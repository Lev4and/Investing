#!/bin/sh
#!/usr/bin/env bash
which sh
docker exec $(docker ps -q -f name=$DOCKER_POSTGRES_DB_TEST_CONTAINER_NAME) pg_dump -U $POSTGRES_USER $POSTGRES_DB_TEST_NAME > $POSTGRES_DB_TEST_DATA_DIR/backups/$POSTGRES_DB_TEST_NAME/"dump_$(date +"%F %T").sql"