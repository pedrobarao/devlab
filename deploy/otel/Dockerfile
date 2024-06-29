FROM otel/opentelemetry-collector-contrib:latest
COPY ./deploy/otel/otel-collector-config.yaml /etc/otel-collector-config.yaml
EXPOSE 4317
EXPOSE 4318
CMD ["--config=/etc/otel-collector-config.yaml"]
