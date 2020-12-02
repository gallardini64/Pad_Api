

CREATE TABLE juegos (
	juego_id INT IDENTITY (1, 1) PRIMARY KEY,
	titulo VARCHAR (255) NOT NULL,
	imagen VARCHAR (255),
	fecha_lanzamiento DATE NOT NULL,
	genero_id INT NOT NULL,
	desarrollador_id INT NOT NULL,
	distribuidor_id INT NOT NULL,
	FOREIGN KEY (genero_id) REFERENCES generos (genero_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (distribuidor_id) REFERENCES distribudores (distribuidor_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (desarrollador_id) REFERENCES desarrolladores (desarrollador_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE generos (
	genero_id INT IDENTITY (1, 1) PRIMARY KEY,
	genero_descripcion VARCHAR (255) NOT NULL
);

CREATE TABLE etiquetas (
	etiqueta_id INT IDENTITY (1, 1) PRIMARY KEY,
	etiqueta_descripcion VARCHAR (255) NOT NULL
);

CREATE TABLE juego_etiqueta (
	PRIMARY KEY (juego_id, etiqueta_id),
	juego_etiqueta_id INT,
	FOREIGN KEY (juego_id) REFERENCES juegos (juego_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (etiqueta_id) REFERENCES etiquetas (etiqueta_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE desarrolladores (
	desarrollador_id INT IDENTITY (1, 1) PRIMARY KEY,
	desarrollador_fecha_fundacion DATE NOT NULL,
	desarrollador_razonsocial VARCHAR (255) NOT NULL
);

CREATE TABLE distribudores (
	distribuidor_id INT IDENTITY (1, 1) PRIMARY KEY,
	distribuidor_fecha_fundacion DATE NOT NULL,
	distribuidor_razonsocial VARCHAR (255) NOT NULL
);

CREATE TABLE copias (
	copias_id INT IDENTITY (1, 1) PRIMARY KEY,
	juego_id INT NOT NULL,
	FOREIGN KEY (juego_id) REFERENCES juegos (juego_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE ventas (
	ventas_id INT IDENTITY (1, 1) PRIMARY KEY, 
	venta_fecha DATE NOT NULL,
	ventas_total DECIMAL (10, 2) NOT NULL,
	usuario_id INT NOT NULL,
	FOREIGN KEY (usuario_id) REFERENCES usuarios (usuario_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE lineasventa (
	lineaventa_id INT IDENTITY (1, 1) PRIMARY KEY,
	subtotal DECIMAL (10, 2) NOT NULL,
	copias_id INT NOT NULL,
	ventas_id INT NOT NULL,
	cantidad INT NOT NULL,
	FOREIGN KEY (copias_id) REFERENCES copias (copias_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (ventas_id) REFERENCES ventas (ventas_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE usuarios (
	usuario_id INT IDENTITY (1, 1) PRIMARY KEY,
	nombre VARCHAR (255) ,
	apellido VARCHAR (255) ,
	contraseña VARCHAR (255) NOT NULL,
	nickname VARCHAR (255) NOT NULL,
	email VARCHAR (255) NOT NULL
);


CREATE TABLE existencias (
	existencia_id INT IDENTITY (1, 1) PRIMARY KEY,
	existencia_cantidad DECIMAL (10, 2) NOT NULL,
	existencia_precio DECIMAL (10, 2) NOT NULL
	juego_id INT NOT NULL,
	FOREIGN KEY (juego_id) REFERENCES juegos (juego_id) ON DELETE CASCADE ON UPDATE CASCADE
);

use TiendaVJDB

CREATE PROCEDURE SP_ValidarUsuario 
@email varchar(255),  
@password varchar(255) 
AS 
BEGIN  
SELECT usuario_id,email,nombre,apellido  
FROM usuarios  
WHERE email=@email AND contraseña=@password 
END















