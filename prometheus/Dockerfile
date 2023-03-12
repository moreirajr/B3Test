FROM prom/prometheus:v2.37.6 as prometheus-image
COPY ./prometheus.yml /etc/prometheus

VOLUME ./data
EXPOSE 9090