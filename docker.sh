#!/bin/sh

# Define variables
username="admin"
password="password"
data_dir="/portainer/Files/AppData/Config/couchdb/data"
etc_dir="/portainer/Files/AppData/Config/couchdb/etc"

# Run the Docker command
docker run --name couchdb-demo -d --restart always \
    -e COUCHDB_USER=${username} \
    -e COUCHDB_PASSWORD=${password} \
    -v ${data_dir}:/opt/couchdb/data \
    -v ${etc_dir}:/opt/couchdb/etc/local.d \
    -p 5984:5984 couchdb