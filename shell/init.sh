#!/bin/sh
#!/usr/bin/env bash
which sh
cd /var/var/
mkdir projects
cd projects
git clone https://github.com/Lev4and/Investing.git
cd Investing
bash exportEnv.sh
bash foldersCreate.sh
bash dockerInit.sh