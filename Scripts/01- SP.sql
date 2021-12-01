DELIMITER $$
CREATE PROCEDURE altaTecnologia (unIdTecnologia TINYINT, unTecnologia VARCHAR(45), unCostoBase DECIMAL(10.2))
BEGIN
        INSERT INTO tecnologia (idTecnologia, tecnologia, costoBase)
        VALUES     (unIdTecnologia, unTecnologia, unCostoBase);
END $$

DELIMITER $$
CREATE PROCEDURE altaRequerimiento (unIdRequerimiento INT, unIdProyecto SMALLINT, unIdTecnologia TINYINT,
                                        unDescripcion VARCHAR(45), unComplejidad TINYINT UNSIGNED)
BEGIN
        INSERT INTO requerimiento (idRequerimiento, idProyecto, idTecnologia, descripcion, complejidad)
        VALUES    (unIdRequerimiento, unIdProyecto, unIdTecnologia, unDescripcion, unComplejidad);
END $$

DELIMITER $$
CREATE PROCEDURE altaTarea (unIdRequerimiento INT, unCuil INT, unInicio DATE, unFin DATE)
BEGIN
        INSERT INTO tarea (idRequerimiento, cuil, inicio, fin)
        VALUES    (unIdRequerimiento, unCuil, unInicio, unFin);
END $$

DELIMITER $$
CREATE PROCEDURE altaEmpleado (unCuil INT, unNombre VARCHAR(50), unApellido VARCHAR(50), unContratacion DATE)
BEGIN
        INSERT INTO empleado (cuil, nombre, apellido, contratacion)
        VALUES    (unCuil, unNombre, unApellido, unContratacion);
END $$

DELIMITER $$
CREATE PROCEDURE altaProyecto (unIdProyecto SMALLINT, unCuit INT, unDescripcion VARCHAR(200),
                                unPresupuesto DECIMAL(10.2), unInicio DATE, unFin DATE)
BEGIN
        INSERT INTO proyecto (idProyecto, cuit, descripcion, presupuesto, incio, fin)
        VALUES    (unIdProyecto, unCuit, unDescripcion, unPresupuesto, unInicio, unFin);
END $$

DELIMITER $$
CREATE PROCEDURE altaCliente (unCuit INT, unRazonSocial VARCHAR(50))
BEGIN
        INSERT INTO cliente (cuit, razonSocial)
        VALUES    (unCuit, unRazonSocial);
END $$

DELIMITER $$
CREATE PROCEDURE asignarExperiencia (unCuil INT, unIdTecnologia TINYINT, unCalificacion TINYINT UNSIGNED)
BEGIN
        IF(EXISTS(SELECT * 
        FROM experiencia
        WHERE cuil = unCuil AND idTecologia = unIdTecnologia))
        THEN 
        UPDATE experiencia
        SET calificacion = unCalificacion
        WHERE cuil = unCuil 
        AND idTecologia = unIdTecnologia 
        AND calificacion != calificacion;
        ELSE
        INSERT INTO experiencia (cuil, idTecnologia, calificacion)
        VALUES(unCuil, unIdTecnologia, unCalificacion);
        END IF;
END $$

DELIMITER $$
CREATE PROCEDURE finalizarTarea (unIdRequerimiento INT, unCuil INT, unInicio DATE, unFin DATE)
BEGIN
        UPDATE tarea
        SET fin = unFin
        WHERE cuil = unCuil 
        AND idRequerimiento = unIdRequerimiento
        AND fin = NULL;
END $$

-- 



DELIMITER $$
CREATE FUNCTION complejidadPromedio (unIdProyecto SMALLINT) RETURNS FLOAT
BEGIN
        DECLARE cpromedio FLOAT;
        SELECT  AVG(complejidad) INTO cpromedio
        FROM requerimiento
        WHERE idProyecto = unIdProyecto;
        RETURN cpromedio;
END $$


DELIMITER $$
CREATE FUNCTION sueldoMensual (unCuil INT) RETURNS DECIMAL(10.2)
BEGIN
        DECLARE sueldo DECIMAL(10.2);
        SELECT  (DATEDIFF(now(), contratacion)/365) * 1000 +
                SUM(calificacion * costoBase) INTO sueldo
        FROM empleado E
        JOIN experiencia EX USING (cuil)
        JOIN tecnologia USING (idTecnologia)
        WHERE E.cuil = unCuil;
        RETURN sueldo;
END $$


DELIMITER $$
CREATE FUNCTION costoProyecto (unIdProyecto SMALLINT) RETURNS DECIMAL(10.2)
BEGIN
        DECLARE costoP DECIMAL(10.2);
        SELECT  SUM(complejidad * costoBase) INTO costoPY
        FROM requerimiento
        JOIN tecnologia USING (idTecnologia)
        Where idProyecto = unIdProyecto;
        RETURN costoP;
END $$




