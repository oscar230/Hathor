#!/bin/bash
docker-compose up --force-recreate --build -d
docker image prune -f
docker ps | grep "hathor"