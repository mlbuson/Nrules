# NRules Kafka API Example

Este proyecto es un ejemplo de un motor de reglas implementado en **NRules** que utiliza **Kafka** para enviar notificaciones y maneja clientes de un banco para determinar si son aptos para una promoción. Además, se ha implementado un **API Gateway** en ASP.NET Core que expone estas reglas a través de una API REST.

## Características del Proyecto

- **Reglas de Promoción**: Evalúa si un cliente es apto para una promoción en función de su **DNI** (Debe tener 8 dígitos) y **sexo** (Debe ser femenino).
- **Manejo de Errores**: Si el cliente no cumple con los requisitos (DNI inválido o no es un cliente existente), se genera un error y se envía un mensaje a una cola Kafka.
- **API Gateway**: Expone una API REST para que los clientes puedan verificar si son aptos para la promoción.
- **Integración con Kafka**: Envía mensajes de errores o notificaciones a un tópico Kafka.

## Repositorio en GitHub

El código de este proyecto está disponible en el siguiente repositorio de GitHub:  
[https://github.com/mlbuson/Nrules](https://github.com/mlbuson/Nrules)

## Requisitos Previos

- **.NET Core SDK 3.1 o superior**.
- **Kafka** debe estar instalado y configurado. Puedes utilizar [Confluent Kafka](https://docs.confluent.io/platform/current/quickstart/ce-docker-quickstart.html) para levantar un contenedor de Docker con Kafka localmente.
- **NRules** instalado a través de NuGet.
- **Confluent.Kafka** instalado a través de NuGet.

## Instalación

1. Clona este repositorio o descarga el archivo ZIP y extráelo en tu máquina local.

2. Instala las dependencias de **NRules** y **Confluent.Kafka** ejecutando el siguiente comando dentro de la carpeta del proyecto:

```bash
dotnet add package NRules
dotnet add package Confluent.Kafka

