<?php

$conexion = new mysqli('localhost', 'root', '', 'formulario');

if ($conexion->connect_errno) {
    die('Error en la conexión: ' . $conexion->connect_error);
}

// Verificamos si se han enviado los datos del formulario
if (isset($_POST['nombre']) && isset($_POST['apellidos']) && isset($_POST['fecha_nacimiento']) && isset($_POST['ocupacion']) && isset($_POST['contacto']) && isset($_POST['nacionalidad']) && isset($_POST['nivel_ingles']) && isset($_POST['lenguajes'])) {
    
    // Asignamos los valores a las variables
$nombre = $_POST["nombre"];
$apellidos = $_POST["apellidos"];
$fecha_nacimiento = $_POST["fecha_nacimiento"];
$ocupacion = $_POST["ocupacion"];
$contacto = $_POST["contacto"];
$nacionalidad = $_POST["nacionalidad"];
$nivel_ingles = $_POST["nivel_ingles"];
$lenguajes = implode(", ", $_POST["lenguajes"]);
$aptitudes = $_POST["aptitudes"];
$habilidades = implode(", ", $_POST["habilidades"]);
$perfil = $_POST["perfil"];



$sql = "INSERT INTO registros (nombre, apellidos, fecha_nacimiento, ocupacion, contacto, nacionalidad, nivel_ingles, lenguajes, aptitudes, habilidades, perfil) 
        VALUES ('$nombre', '$apellidos', '$fecha_nacimiento', '$ocupacion', '$contacto', '$nacionalidad', '$nivel_ingles', '$lenguajes', '$aptitudes', '$habilidades', '$perfil')";

if (!$conexion->query($sql)) {
  die('Error al insertar los datos: ' . $conexion->error);
}

echo "Los datos se guardaron correctamente";
} else {
echo "No se enviaron los datos del formulario";
}

extract($_REQUEST);
$file=fopen("form-save.txt","a");

fwrite($file,"nombre: ");
fwrite($file, $nombre ."\n");
fwrite($file,"apellidos: ");
fwrite($file, $nombre ."\n");
fwrite($file,"fecha de nacimiento: ");
fwrite($file, $fecha_nacimiento ."\n");
fwrite($file,"ocupacion: ");
fwrite($file, $ocupacion ."\n");
fwrite($file,"contacto: ");
fwrite($file, $contacto ."\n");
fwrite($file,"nacionalidad: ");
fwrite($file, $nacionalidad ."\n");
fwrite($file,"nivel de ingles: ");
fwrite($file, $nivel_ingles ."\n");
fwrite($file,"lenguajes: ");
fwrite($file, $lenguajes ."\n");
fwrite($file,"aptitudes: ");
fwrite($file, $aptitudes ."\n");
fwrite($file,"habilidades: ");
fwrite($file, $habilidades ."\n");
fwrite($file,"perfil: ");
fwrite($file, $perfil ."\n");
fclose($file);

$conexion->close();

?>