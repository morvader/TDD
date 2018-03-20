Desarrollar una clase que se comporte como una lista (hereda de Enumerable) de strings únicos (sin repeticiones) en orden LIFO

- El último elemento añadido va al principio y el último al final
- Los elementos se pueden acceder por su índice que comnzará en 0
- Los accesos con indice fuera de rago producen una excepción: "Fuera de rango"
- Las inserciones duplicadas son llevadas al inicio de la lista. Es decir, el elemento quedará al principio una única vez.
- Inicialmente la lista está vacía
- Inserciones nulas o cadenas vacías no están permitidas
- Se puede especificar un tamaño máximo, de manera que los últimos elementos añadidos se irán eliminando
