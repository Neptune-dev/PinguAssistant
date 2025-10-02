<?php

// api entrypoint
// pour l'instant, le motif de la requete est attendu en query param

require_once('includes/helpers.php');

$pdo = openDB();

if ($_SERVER["REQUEST_METHOD"] == "POST")
{
    if ($_GET["req"] == "login")
    {
        $username = $_POST['username'];
        $pwd = $_POST['pwd'];

        $stmt = $pdo->prepare("SELECT * FROM Users WHERE Username=?");
        $stmt->execute([$username]);
        $user = $stmt->fetch();

        if ($user && password_verify($pwd, $user["Pwd"])) {
            $_SESSION["user"] = $user;
            $data =
            [
                'status' => '200',
                'req' => $_GET["req"]
            ];
            http_response_code(200);
        } else {
            $data =
            [
                'status' => '401',
                'req' => $_GET["req"]
            ];
            http_response_code(401);
        }
    } elseif ($_GET["req"] == "signin")
    {
        $username = $_POST['username'];
        $pwd = $_POST['pwd'];

        $hashedPassword = password_hash($pwd, PASSWORD_DEFAULT);
        $stmt = $pdo->prepare("INSERT INTO Users (Username, Pwd, isAdmin) VALUES (?,?,?)");
        $stmt->execute([$username, $hashedPassword, 0]);

        $data =
        [
            'status' => '201',
            'req' => $_GET["req"]
        ];
        http_response_code(200);
    } else
    {
        $data =
        [
            'status' => '400',
            'req' => $_GET["req"]
        ];
        http_response_code(400);
    }
} else
{
    $data =
    [
        'status' => '400',
    ];
    http_response_code(400);
}

header('Content-Type: application/json; charset=utf-8');
echo json_encode($data);
exit();
?>