# influxdb

## setup docs
https://docs.influxdata.com/influxdb/v2/get-started/setup/#run-initial-setup-process

## docker command to install + run influxdb
```docker run --detach --name influxdb2 --publish 8086:8086 --mount type=volume,source=influxdb2-data,target=/var/lib/influxdb2 --mount type=volume,source=influxdb2-config,target=/etc/influxdb2 --env DOCKER_INFLUXDB_INIT_MODE=setup --env DOCKER_INFLUXDB_INIT_USERNAME=admin --env DOCKER_INFLUXDB_INIT_PASSWORD=adminadmin --env DOCKER_INFLUXDB_INIT_ORG=james-org --env DOCKER_INFLUXDB_INIT_BUCKET=james-bucket influxdb:2```


## influxdb localhost

```http://localhost:8086/```

