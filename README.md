# SistemaMeteorologico

[![Build Status](https://travis-ci.com/juandausa/SistemaMeteorologico.svg?token=wgeHa5Aanp9L8ryQep1u&branch=master)](https://travis-ci.com/juandausa/SistemaMeteorologico)

## Consideraciones
A continuación se detallan las interpretaciones del enunciado:
- Se habla de período de una condición meteorológica, la cual se entiende como una cantidad de días consecutivos con el mismo estado del clima. Es decir, si hay tres días de lluvia, luego uno de sequía y luego otro día de lluvia se tendrán dos períodos de lluvia y uno de sequía.
- Se toma un cuarto estado no descrito como 'Otro', que se corresponde con las condiciones de los planetas que no se ajustan con las descritas.
- Se considera un año como 365 días.
- Se considera que la máxima lluvia se da para el triángulo de perímetro máximo para el plazo de pronóstico solicitado. Es decir que no se calcula el triángulo de mayor perímetro posible, si no, el de máximo entre los calculados.
- Otra interpretación es que el pico se da para el de mayor perímetro según las restricciones planteadas. Esto se puede obtener el mayor mediante la maximización de la función perímetro en función de los ángulos, sujeto a las restricciones del problema o por fuerza bruta.
- Otra posible, es suponer que el día del pico de lluvia se produce para el triángulo de mayor tamaño del período. Esto presenta contradicciones con la pregunta planteada que sugiere que existe un día de lluvia máxima para todo el pronóstico y no uno por período.
- Una asunción más general es interpretar que el pico de lluvia se da si el triángulo formado es el de mayor perímetro solo sujeto a la restricción de los vértices dentro de los círculos concéntricos.
- Cada día tendrá solo una característica climática, es decir que para cada día el mismo solo podrá ser seco, lluvioso, de condiciones normales de presión y temperatura o del estado 'Otro'.
- Se asume que los planetas arrancan con 0 grados de desvio sobre el eje horizontal.

## Requerimientos para el Build
- [Net core 3.1 en adelante](https://dotnet.microsoft.com/download)

## Auto Deploy
- El sistema se encuentra en un servidor de integración que a su vez se encarga del despliegue automático por cada build exitoso. Esto se ha configurado mediante la integración con travis y heroku utilizando los buildpacks [monorepo](https://github.com/jan-tee/heroku-buildpack-monorepo) y [dotnetcore](https://github.com/jincod/dotnetcore-buildpack/). El primero se utiliza con el fin de seleccionar cuál de los proyectos será desplegado y el segundo para la generación del paquete a desplegar.

## Dependencias
- Se ha tomado una implementación de web api desde [rosymoggy](https://github.com/rosymoggy/HwEFCoreWebAPI)