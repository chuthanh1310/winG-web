<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <h2>Test database</h2>
    <?php
    $connection = pg_connect("host=localhost dbname=wing user=postgres password=123456");
    if (!$connection) {
        echo "Error connecting to database. <br>";
    } else {
        $tables = array("comics", "chapters","musicvideos","albums","artist","singles","threed", "product"); // Danh sách các bảng cần hiển thị

        // Lặp qua mỗi bảng để hiển thị dữ liệu
        foreach ($tables as $table) {
            $result = pg_query($connection, "SELECT * FROM $table");
            if (!$result) {
                echo "Error executing query for table $table. <br>";
            } else {
                echo "<h3>$table</h3>"; // Tiêu đề của bảng
                echo "<table>";
                $row = pg_fetch_assoc($result);
                echo "<tr>";
                // Hiển thị các cột
                foreach ($row as $key => $value) {
                    echo "<th>$key</th>";
                }
                echo "</tr>";
                // Hiển thị dữ liệu từng hàng
                while ($row) {
                    echo "<tr>";
                    foreach ($row as $value) {
                        echo "<td>$value</td>";
                    }
                    echo "</tr>";
                    $row = pg_fetch_assoc($result);
                }
                echo "</table>";
            }
        }
        // Đóng kết nối đến cơ sở dữ liệu
        pg_close($connection);
    }
    ?>
</body>
</html>
