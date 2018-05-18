<?php

/* 
 * login.php
 * @author Brian
 */

include 'header.php'
?>

<table>
    <form action='../libs/Shop.php' method='GET'>
    <tr><td>Email:</td>
        <td><input name="email" type="email" value="" required="true" maxlength="29"/></td>
    </tr>
    <tr><td>Password:</td>
        <td><input name="password" type="password" value="" required="true" maxlength="18"/></td>
    </tr>
    <tr>
        <td><input type="submit" name="login" value="Login"/></td>
    </tr>
    </form>
</table>




<?php
echo "<br><br>";
include "footer.php";
?>