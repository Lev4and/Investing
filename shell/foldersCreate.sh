#!/bin/sh
#!/usr/bin/env bash
which sh
mkdir pgadmin-data
mkdir postgres-data
mkdir postgres-data/backups
mkdir postgres-data/backups/$POSTGRES_DB_NAME
mkdir postgres-test-data
mkdir postgres-test-data/backups
mkdir postgres-test-data/backups/$POSTGRES_DB_TEST_NAME
mkdir portainer-data
chown -R 472:472 pgadmin-data
sudo chown -R 5050:5050 pgadmin-data