#!/bin/sh
#!/usr/bin/env bash
which sh
cd /var/var/
mkdir projects
cd projects
git clone https://github.com/Lev4and/Investing.git
cd Investing
rm .env
cp .env.dist .env
export $(egrep -v '^#' .env | xargs -0)
mkdir pgadmin-data
mkdir postgres-data
mkdir postgres-test-data
mkdir portainer-data
chown -R 472:472 pgadmin-data
sudo chown -R 5050:5050 pgadmin-data
docker swarm init
docker stack deploy -c docker-compose.yml investing --prune --with-registry-auth