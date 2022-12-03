#!/bin/sh
#!/usr/bin/env bash
which sh
cd ..
rm .env
cp .env.dist .env
export $(egrep -v '^#' .env | xargs -0)