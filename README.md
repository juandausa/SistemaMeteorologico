# SistemaMeteorologico

[![Build Status](https://travis-ci.com/juandausa/SistemaMeteorologico.svg?token=wgeHa5Aanp9L8ryQep1u&branch=master)](https://travis-ci.com/juandausa/SistemaMeteorologico)

## Consideraciones
A continuación se detallan las interpretaciones del enunciado:
- Se habla de período de una condición meteorólogica, la cual se entiende como una cantidad de días consecutivos con el mismo estado del clima. Es decir, si hay tres días de lluvia, luego uno de sequí y luego otro día de lluvia se tendrán dos períodos de lluvia y uno de sequía.
- Se toma un cuarto estado no descrito como 'Otro', que se corresponde con las condiciones de los planetas que no se ajustan con las descritas.
- Se considera un año como 365 días.
- Se considera que la máxima lluvia se da para el triángulo de perímetro máximo para el plazo de pronóstico solicitado. Es decir que no se cacula el triángulo de mayor perímetro posible, si no el de máximo entre los calculados.
  - Se podría obtener el mayor perímetro mediante la maximización de la función perímetro en función de los ángulos. Deberán incluirse restricciones adicionales para asegurar que la figura formada sea un triángulo que incluya al centro de coordenadas.
  - Otra posible interpretación es que el día del pico de lluvia se produce para el triángulo de mayor tamaño del período. Esto presenta contradicciones con la pregunta planteada que sugiere que existe un día de lluvia máxima para todo el pronóstico y no uno por período.
- Cada día tendrá solo una característica climática, es decir que para cada día el mismo solo podrá ser seco, lluvioso, de condiciones normales de presión y temperatura o del estado 'Otro'.

## Requerimientos para el Build
- [Net core 3.0 en adelante](https://dotnet.microsoft.com/download)

## Dependencias
- Se ha tomado una implementación de web api desde [rosymoggy](https://github.com/rosymoggy/HwEFCoreWebAPI)