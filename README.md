# Consumidor - Productor


Requerimientos:

1. Existen un solo productor y un solo consumidor.

2. Se cuenta con un “contenedor” con capacidad para 25 elementos, en el cual el productor colocará y el consumidor retirará elementos.

3. El “contenedor”, lógicamente es un buffer circular y acotado, es decir al llegar a la última casilla (25) comenzará nuevamente en la casilla 1.

4. El producto puede ser: números, caracteres especiales, letras, etc.

5. Solo puede ingresar uno a la vez al contenedor.

6. Para que el Productor pueda entrar, debe haber espacio en el contenedor.

7. Para que el Consumidor pueda entrar, debe existir producto.

8. En la pantalla debe aparecer:

    a. El contenedor con los espacios claramente marcados y numerados.

    b. La información del productor, es decir, mostrar si está dormido, trabajando, cuando intente ingresar al contenedor, etc.

    c. La información del consumidor, dormido, trabajando, cuando intente ingresar, etc.

    d. Mensajes que indiquen en todo momento, quien está trabajando, o quien intenta trabajar, o si está dormido.

9. Deben manejarse tiempos aleatorios para dormir al productor y al consumidor.

10. Al “despertar” intentará producir y/o consumir respectivamente, verificando que pueda hacerlo según sus condiciones.

11. Al entrar al buffer podrán producir y/o consumir de 2 a 5 elementos en cada entrada.

12. El productor colocará elementos en orden,  comenzando con la primera casilla y continuando en la casilla donde quedo.

13. El consumidor quitará elementos en orden, comenzando también por la primera casilla y continuando en donde quedo la última entrada.

14. Cuando el productor y/o el consumidor lleguen a la casilla 25, irán de nuevo a la 1 y continuarán produciendo y/o consumiendo respectivamente.

15. El programa terminara cuando se presione la tecla “ESC”.
