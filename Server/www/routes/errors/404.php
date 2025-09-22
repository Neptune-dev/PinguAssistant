<?php
ob_start();
?>

<h1>404 Not Found</h1>

<p>Ressource non trouvée : <?= $route ?></p>

<?php
$title = '404';
$content = ob_get_clean();
require('views/base.php');
?>