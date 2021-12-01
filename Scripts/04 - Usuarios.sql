Drop User If Exists 'administrador'@'%';
Drop User If Exists 'pm'@'10.3.45.%';
Drop User If Exists 'empleado'@'10.3.45.%';

Create User If Not Exists 'administrador'@'%';
Create User If Not Exists 'pm'@'10.3.45.%';
Create User If Not Exists 'empleado'@'10.3.45.%';

-- Administrador

Grant select On softwarefactory.tarea TO 'administrador'@'%';
Grant select On softwarefactory.experiencia TO 'administrador'@'%';
Grant select On softwarefactory.requerimiento TO 'administrador'@'%';
Grant select, Insert On softwarefactory.tecnologia TO 'administrador'@'%';
Grant select, Insert On softwarefactory.cliente TO 'administrador'@'%';
Grant select, Insert On softwarefactory.empleado TO 'administrador'@'%';
Grant select, Insert, Update On softwarefactory.proyecto TO 'administrador'@'%';

-- Pm

Grant select On softwarefactory.tecnologia TO 'pm'@'10.3.45.%';
Grant select On softwarefactory.cliente TO 'pm'@'10.3.45.%';
Grant select On softwarefactory.proyecto TO 'pm'@'10.3.45.%';
Grant select, Insert On softwarefactory.requerimiento TO 'pm'@'10.3.45.%';
Grant select, Insert On softwarefactory.empleado TO 'pm'@'10.3.45.%';
Grant select, Insert, Update (calificacion) On softwarefactory.experiencia TO 'pm'@'10.3.45.%';
Grant select, Insert, Update (fin) On softwarefactory.tarea TO 'pm'@'10.3.45.%';

-- Empleado

Grant select On softwarefactory.tecnologia TO 'empleado'@'10.3.45.%';
Grant select On softwarefactory.cliente TO 'empleado'@'10.3.45.%';
Grant select On softwarefactory.empleado TO 'empleado'@'10.3.45.%';
Grant select On softwarefactory.tarea TO 'empleado'@'10.3.45.%';
Grant select On softwarefactory.experiencia TO 'empleado'@'10.3.45.%';
Grant select On softwarefactory.requerimiento TO 'empleado'@'10.3.45.%';
Grant select On softwarefactory.proyecto TO 'empleado'@'10.3.45.%';


