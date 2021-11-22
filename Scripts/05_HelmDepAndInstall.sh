# There are no dependencies in this chart, but it's important to know how you need to handle them
helm dep update ./Charts/full

kubectl create namespace kda-full-namespace

# Install the chart named as: KubernetesDummyApiRelease
helm install kubernetesdummyapi-release ./Charts/full --namespace=kda-full-namespace