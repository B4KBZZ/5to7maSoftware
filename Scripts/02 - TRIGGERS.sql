                           RESPUESTAS
DELIMITER $$

-- Antes de hacer un Insert en Tarea, si la calificación del empleado es menor a la complejidad del requerimiento 
-- no se tiene que permitir el Insert y se tiene que mostrar la leyenda "Calificación insuficiente".

Drop Trigger If Exists befInsTarea $$
Create Trigger befInsTarea Before Insert On tarea
For Each Row
Begin
               if(Exists(Select * 
                 From experiencia
                  Join requerimiento Using (idTecnologia) 
                  Where calificacion < complejidad 
                  And cuil = new.cuil 
                  And idRequerimiento = new.idRequerimiento)) THEN
               SIGNAL SQLSTATE '45000'
                  Set MESSAGE_TEXT = 'Calificacion insuficiente';
        END IF;
END $$

DELIMITER $$

-- Realizar un trigger para que al ingresar un usuario, le asigne por defecto 
-- experiencia en todas las tecnologías disponibles con calificación igual a CERO.

Drop Trigger If Exists aftInsEmpleado $$
Create Trigger aftInsEmpleado After Insert On empleado
For Each Row
Begin
        Insert Into softwarefactory.experiencia(cuil, idTecnologia, calificacion)
        Select new.cuil, idTecnologia, 0 
           From softwarefactory.tecnologia;
END $$




DELIMITER $$

-- alta tarea

Drop Procedure If Exists altaTarea $$
Create Procedure altaTarea (unIdRequerimiento Int, unCuil Int,         unInicio Date, unFin Date)
Begin
        Insert Into tarea (idRequerimiento, cuil, inicio, fin)
        Values    (unIdRequerimiento, unCuil, unInicio, unFin);
END $$



DELIMITER $$

-- alta empleado

Drop Procedure If Exists altaEmpleado $$
Create Procedure altaEmpleado (unCuil Int, unNombre Varchar(50),   unApellido Varchar(50), unContratacion DATE)
Begin
    Insert Into empleado (cuil, nombre, apellido, contratacion)

    Values (unCuil, unNombre, unApellido, unContratacion);
END $$


-- Insert befInsTarea
Call altaTarea(1, 1000, '2021-01-06', '2021-06-20');


-- Insert aftInsEmpleado
Call altaEmpleado(1, 'Bruce', 'Kim', '2021-12-31');


-- Consulta de calificacion 0 a todas las tecnologias
Select *
From experiencia
Where cuil = 1;


