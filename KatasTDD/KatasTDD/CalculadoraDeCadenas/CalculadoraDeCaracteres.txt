Enunciado:
- Crear una calculadora con un método con la siguiente signatura: Sumar(string numeros), donde:
	- El método puede tomar 0,1 o 2 números y retornar la suma de los mismos (para una cadena vacía debe devolver 0). Por ejemplo: "", "1" y "1,2"

Recomendaciones:
- Comenzar con el caso de pruebas más simple posible, es decir, cadena vacía y continuar con 1 y 2 argumentos
- Resolver las cosas de la manera más sencilla posible  lo que facilitará escribir test que no habíamos pensado en un principio
- Refactorizar después de cada test pasado

Ampliaciones:
- Permitir que el método gestione una cantidad desconocida de números
- Permitir que el método admita números separados por saltos de línea
	- "1,\n2,3" debe devolver 6
	- "1,\n" no es una entrada válida
- Permitir diferentes delimitadores entre números
	- Para cambiar el delimitador por defecto debe usarse el siguiente formato: “//[delimitador]\n[numeros…]” por ejemplo  “//;\n1;2” debe retornar 3 donde el delimitador es ‘;’ . 
- Si se llama al método con un número negativo debe producidr una excepción con el mensaje: "No se admiten números negativos"
- Ignorar números mayores que 1000, de manera que "2,1001" retorna 2
