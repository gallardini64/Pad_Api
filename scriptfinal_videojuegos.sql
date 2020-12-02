CREATE SCHEMA videojuegos;
go

CREATE SCHEMA ventas;
go



CREATE TABLE videojuegos.generos (
	genero_id INT IDENTITY (1, 1) PRIMARY KEY,
	genero_descripcion VARCHAR (255) NOT NULL
);

CREATE TABLE videojuegos.etiquetas (
	etiqueta_id INT IDENTITY (1, 1) PRIMARY KEY,
	etiqueta_descripcion VARCHAR (255) NOT NULL
);

CREATE TABLE videojuegos.desarrolladores (
	desarrollador_id INT IDENTITY (1, 1) PRIMARY KEY,
	desarrollador_fecha_fundacion DATE NOT NULL,
	desarrollador_razonsocial VARCHAR (255) NOT NULL
);

CREATE TABLE videojuegos.distribudores (
	distribuidor_id INT IDENTITY (1, 1) PRIMARY KEY,
	distribuidor_fecha_fundacion DATE NOT NULL,
	distribuidor_razonsocial VARCHAR (255) NOT NULL
);

CREATE TABLE videojuegos.juegos (
	juego_id INT IDENTITY (1, 1) PRIMARY KEY,
	titulo VARCHAR (255) NOT NULL,
	imagen VARCHAR (255),
	fecha_lanzamiento DATE NOT NULL,
	genero_id INT NOT NULL,
	desarrollador_id INT NOT NULL,
	distribuidor_id INT NOT NULL,
	FOREIGN KEY (genero_id) REFERENCES videojuegos.generos (genero_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (distribuidor_id) REFERENCES videojuegos.distribudores (distribuidor_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (desarrollador_id) REFERENCES videojuegos.desarrolladores (desarrollador_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE videojuegos.juego_etiqueta (
	juego_id INT NOT NULL,
	etiqueta_id INT NOT NULL,
	PRIMARY KEY (juego_id, etiqueta_id),
	juego_etiqueta_id INT,
	FOREIGN KEY (juego_id) REFERENCES videojuegos.juegos (juego_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (etiqueta_id) REFERENCES videojuegos.etiquetas (etiqueta_id) ON DELETE CASCADE ON UPDATE CASCADE
);



CREATE TABLE ventas.copias (
	copias_id INT IDENTITY (1, 1) PRIMARY KEY,
	juego_id INT NOT NULL,
	FOREIGN KEY (juego_id) REFERENCES videojuegos.juegos (juego_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE ventas.usuarios (
	usuario_id INT IDENTITY (1, 1) PRIMARY KEY,
	nombre VARCHAR (255) ,
	apellido VARCHAR (255) ,
	contraseña VARCHAR (255) NOT NULL,
	nickname VARCHAR (255) NOT NULL,
	email VARCHAR (255) NOT NULL
);

CREATE TABLE ventas.ventas (
	ventas_id INT IDENTITY (1, 1) PRIMARY KEY, 
	venta_fecha DATE NOT NULL,
	ventas_total DECIMAL (10, 2) NOT NULL,
	usuario_id INT NOT NULL,
	FOREIGN KEY (usuario_id) REFERENCES ventas.usuarios (usuario_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE ventas.lineasventa (
	lineaventa_id INT IDENTITY (1, 1) PRIMARY KEY,
	subtotal DECIMAL (10, 2) NOT NULL,
	copias_id INT NOT NULL,
	ventas_id INT NOT NULL,
	cantidad INT NOT NULL,
	FOREIGN KEY (copias_id) REFERENCES ventas.copias (copias_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (ventas_id) REFERENCES ventas.ventas (ventas_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE ventas.existencias (
	existencia_id INT IDENTITY (1, 1) PRIMARY KEY,
	existencia_cantidad DECIMAL (10, 2) NOT NULL,
	existencia_precio DECIMAL (10, 2) NOT NULL,
	juego_id INT NOT NULL,
	FOREIGN KEY (juego_id) REFERENCES videojuegos.juegos (juego_id) ON DELETE CASCADE ON UPDATE CASCADE
);

go
CREATE PROCEDURE SP_ValidarUsuario

@email varchar(255),  
@password varchar(255)

AS 
BEGIN  
SELECT usuario_id,email,nombre,apellido  
FROM ventas.usuarios  
WHERE email=@email AND contraseña=@password
END















