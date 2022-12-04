#!/bin/sh
#!/usr/bin/env bash
which sh
docker swarm init
docker stack deploy -c docker-compose.yml investing --prune --with-registry-auth