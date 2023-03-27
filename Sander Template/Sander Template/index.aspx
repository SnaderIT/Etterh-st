<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="Sander_Template.index" %>

<!DOCTYPE html>
<html lang="en">
<head>
<title>CSS Template</title>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<style>
* {
  box-sizing: border-box;
}

body {
  font-family: Arial, Helvetica, sans-serif;
}

/* Style the header */
header {
  background-color: black;
  padding: 40px;
  text-align: center;
  font-size: 35px;
  color: white;
}

/* Create two columns/boxes that floats next to each other */
nav {
  float: left;
  width: 9%;
  height: 800px; /* only for demonstration, should be removed */
  background: #ccc;
  padding: 20px;
  line-height: 80px;
  

}

/* Style the list inside the menu */
nav ul {
  list-style-type: none;
  padding: 0;
}

article {
  float: left;
  padding: 50px;
  width: 91%;
  background-color: white;
  height: 300px; /* only for demonstration, should be removed */
}

/* Clear floats after the columns */
section::after {
  content: "";
  display: table;
  clear: both;
}

/* Style the footer */
footer {
  background-color: black;
  padding: 10px;
  text-align: center;
  color: white;
}

/* Responsive layout - makes the two columns/boxes stack on top of each other instead of next to each other, on small screens */
@media (max-width: 600px) {
  nav, article {
    width: 100%;
    height: auto;
  }
}
</style>
</head>
<body>


<header>
  <h2>Sander's Article</h2>
</header>

<section>
  <nav>
    <ul>
        <Center>
      <li><a href="#">My Work</a></li>
        
      <li><a href="#">Contact</a></li>
        </Center>
    

    </ul>
  </nav>
  
  <article>
   <h1>Article</h1>
    <p>fjasadr</p>
    <p>zntnawh</p>
  </article>
</section>

<footer>
  <p>Laget av Sander</p>
</footer>

</body>
</html>


