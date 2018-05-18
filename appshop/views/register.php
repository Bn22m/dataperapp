<?php
/* 
 * register.php
 * @author Brian
 */
include 'header.php'
?>

<div>
    <?php
    if(isset($_REQUEST["message"]))
    {
        $msg = filter_var($_REQUEST["message"], FILTER_SANITIZE_STRIPPED);
        echo "<br>";
        echo "$msg <br>";
        echo "<br><hr><br>";
    }
    ?>
</div>

<table>
    <form action='../libs/Customers.php' method='POST'>
    <tr><td>Title:</td>
        <td><input name="title" type="text" value="" maxlength="29"/></td>
    </tr>    
    <tr><td>Name:</td>
        <td><input name="name" type="text" value="" required="true" maxlength="29"/></td>
    </tr>
    <tr><td>Surname:</td>
        <td><input name="surname" type="text" value="" required="true" maxlength="29"/></td>
    </tr>
    <tr><td>Email:</td>
        <td><input name="email" type="email" value="" required="true" maxlength="29"/></td>
    </tr>
    <tr><td>Address:</td>
        <td><input name="address" type="text" value="" required="true" maxlength="100"/></td>
    </tr>
    <tr><td>Password:</td>
        <td><input name="password" type="password" value="" required="true" minlength="4" maxlength="8"/></td>
    </tr>
    <tr><td>Topup:</td>
        <td><input name="topup" type="number" value="200" min="100" readonly="true"/></td>
    </tr>
    <tr>
        <td><input type="submit" name="register" value="Register"/></td>
    </tr>
    </form>
</table>







<?php
echo "<br><br>";
include "footer.php";
?>

