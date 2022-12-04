#!/bin/sh
#!/usr/bin/env bash
which sh
rm .env
cp .env.dist .env
export $(egrep -v '^#' .env | xargs -0)