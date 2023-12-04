<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication1.Index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Formulario</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <%--<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css'>--%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>

    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.0.3/css/font-awesome.css'>
    <link rel="stylesheet" href="Css/style.css">
</head>
<body>
    <!--NAVBAR-->
    <nav class="navbar navbar-expand-lg navbar-light">
        <h4 class="InfoModal">Informacion de pedido: <a href="#" data-toggle="modal" data-target="#myModal">Aqui</a></h4>
    </nav>

    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content col-11 col-sm-10 col-md-10 col-lg-6 col-xl-10 p-0 mt-3 mb-2">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Título del Modal</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label>Nombre y apellido:</label>
                    <h6 id="nombreNAV" runat="server"></h6>
                    <br />
                    <label>Telefono:</label>
                    <h6 id="telefonoNAV" runat="server"></h6>
                    <br />
                    <label>Email:</label>
                    <h6 id="emailNAV" runat="server"></h6>
                    <br />
                    <label>Localidad:</label>
                    <h6 id="localidadNAV" runat="server"></h6>
                    <br />
                    <label>Tipo y disposición</label>
                    <h6 id="tipoDisposicionNAV" runat="server"></h6>
                    <br />
                    <label>Capacidad de carga por eje:</label>
                    <h6 id="cargaNAV" runat="server"></h6>
                    <br />
                    <label>Tipo de llantas:</label>
                    <h6 id="tipoLlantasNAV" runat="server"></h6>
                    <br />
                    <label>Trocha del eje:</label>
                    <h6 id="trochaNAV" runat="server"></h6>
                    <br />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <!-- Otros botones del pie del modal si es necesario -->
                </div>
            </div>
        </div>
    </div>


    <!-- partial:index.partial.html -->
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-11 col-sm-10 col-md-10 col-lg-6 col-xl-10 text-center p-0 mt-3 mb-2">
                <div class="card px-0 pt-4 pb-0 mt-3 mb-3">
                    <h2 id="heading">Completá nuestro formulario de pedido</h2>
                    <p>
                        De esta forma vamos a saber de que se trata tu proyecto y así poder asesorarte de manera correcta.
                    </p>
                    <form id="msform" runat="server">
                        <br>
                        <!-- fieldsets -->
                        <asp:MultiView runat="server" ActiveViewIndex="0" ID="multiView">
                            <!-- PAGINA 1 -->
                            <asp:View runat="server" ID="view1">
                                <fieldset>
                                    <div class="form-card">
                                        <div class="row">
                                            <div class="col-7">
                                                <h2 class="fs-title">Datos personales</h2>
                                            </div>
                                            <div class="col-5">
                                                <h2 class="steps">Paso 1 - 6</h2>
                                            </div>
                                        </div>
                                        <label runat="server" id="lblErrorNombre" style="color: red;"></label>
                                        <asp:TextBox runat="server" ID="nombreTextBox" placeholder="Nombre" CssClass="form-control" />
                                        <label runat="server" id="lblErrorLocalidad" style="color: red;"></label>
                                        <asp:TextBox runat="server" ID="localidadTextBox" placeholder="Localidad" CssClass="form-control" />
                                        <label runat="server" id="lblErrorEmail" style="color: red;"></label>
                                        <asp:TextBox runat="server" ID="emailTextBox" placeholder="Email" CssClass="form-control" />
                                        <label runat="server" id="lblErrorTelefono" style="color: red;"></label>
                                        <asp:TextBox runat="server" ID="telefonoTextBox" placeholder="Teléfono" CssClass="form-control" />
                                    </div>
                                    <asp:Button runat="server" name="next" ID="nextButtonPage1" CssClass="next action-button" Text="Siguiente" OnClick="nextButtonPage1_Click" />
                                </fieldset>
                            </asp:View>
                            <!-- PAGINA 2 -->
                            <asp:View runat="server" ID="view2">
                                <fieldset>
                                    <div class="form-card">
                                        <div class="row">
                                            <div class="col-7">
                                                <h2 class="fs-title">Determinar Tipo y Disposición</h2>
                                            </div>
                                            <div class="col-5">
                                                <h2 class="steps">Paso 2 - 6</h2>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="descripcion pb-3">
                                            Los acoplados y trailers, en general, se fabrican en base a esos 6 tipos diferentes de cantidad y disposición de ejes. Los de 1 y 2 ejes, los más comunes y recomendables.
                                        </div>
                                        <br />
                                        <label runat="server" id="lblErrorPagina2" style="color: red;"></label>
                                        <div class="check-image-row overflow-auto">
                                            <div class="check-image-row">
                                                <div class="check-image-container">
                                                    <asp:CheckBox runat="server" ID="CheckBox1"  name="CheckBox1"  />
                                                    <img src="Resources/a.jpg" alt="Imagen 1">
                                                </div>

                                                <div class="check-image-container">
                                                    <asp:CheckBox runat="server" ID="CheckBox2"  name="CheckBox2" />
                                                    <img src="Resources/b.jpg" alt="Imagen 1">
                                                </div>

                                                <div class="check-image-container">
                                                    <asp:CheckBox runat="server" ID="CheckBox3"  name="CheckBox3"  />
                                                    <img src="Resources/c.jpg" alt="Imagen 1">
                                                </div>

                                                <div class="check-image-container">
                                                    <asp:CheckBox runat="server" ID="CheckBox4"  name="CheckBox4"  />
                                                    <img src="Resources/d.jpg" alt="Imagen 1">
                                                </div>

                                                <div class="check-image-container">
                                                    <asp:CheckBox runat="server" ID="CheckBox5"  name="CheckBox5"  />
                                                    <img src="Resources/e.jpg" alt="Imagen 1">
                                                </div>

                                                <div class="check-image-container">
                                                    <asp:CheckBox runat="server" ID="CheckBox6"  name="CheckBox6"  /> <!--AutoPostBack="true" OnCheckedChanged="CheckBox_CheckedChanged" ClientIDMode="Static" -->
                                                    <img src="Resources/f.jpg" alt="Imagen 1">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Button runat="server" name="next" ID="nextButtonPage2" CssClass="next action-button" Text="Siguiente" OnClick="nextButtonPage2_Click" />
                                    <asp:Button ID="previusButtonPage2" runat="server" name="previous" class="previous action-button-previous" Text="Volver" OnClick="previusButtonPage2_Click" />
                                </fieldset>
                            </asp:View>

                            <!-- PAGINA 3 -->
                            <asp:View runat="server" ID="view3">
                                <fieldset>
                                    <div class="form-card">
                                        <div class="row">
                                            <div class="col-7">
                                                <h2 class="fs-title">Determinar la Capacidad de Carga por Cada Eje (B/2)</h2>
                                            </div>
                                            <div class="col-5">
                                                <h2 class="steps">Paso 3 - 6</h2>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="descripcion pb-3">
                                            Es el resultado de la división entre: El peso bruto del trailer B y la Cantidad de ejes (en este caso 2 ejes). Esto es válido para todo tipo de configuración.
                                        </div>
                                        <br />
                                        <img src="Resources/carga.jpg" alt="Imagen 1" class="img-carga">
                                        <br />
                                        <label runat="server" id="lblErrorCarga" style="color: red;"></label>
                                        <asp:TextBox runat="server" ID="txtCarga" placeholder="B/2:" CssClass="form-control" />
                                    </div>
                                    <asp:Button name="next" ID="nextButtonPage3" CssClass="next action-button" Text="Siguiente" runat="server" OnClick="nextButtonPage3_Click" />
                                    <asp:Button ID="previusButtonPage3" runat="server" name="previous" class="previous action-button-previous" Text="Volver" OnClick="previusButtonPage3_Click" />
                                </fieldset>
                            </asp:View>

                            <!-- PAGINA 4 -->
                            <asp:View runat="server" ID="view4">
                                <fieldset>
                                    <div class="form-card">
                                        <div class="row">
                                            <div class="col-7">
                                                <h2 class="fs-title">Determinar Tipo de Llantas: ¿Simple o Dual?</h2>
                                            </div>
                                            <div class="col-5">
                                                <h2 class="steps">Paso 4 - 6</h2>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="descripcion pb-3">
                                            Los trailers y acoplados en general, pueden tener 2 o 4 ruedas por eje. Muchas veces, para bajar el centro de gravedad de la unidad, se opta por rodado dual de menor diámetro, para compensar la carga que soporta cada neumático en comparación a un rodado simple de mayor dimensión.
                                        </div>
                                        <br />
                                        <label runat="server" id="lblErrorPagina4" style="color: red;"></label>
                                        <div class="check-image-row overflow-auto">
                                            <div class="check-image-row">
                                                <div class="check-image-container">
                                                    <asp:CheckBox runat="server" ID="CheckBox7"  name="CheckBox7"/>
                                                    <img src="Resources/simple.jpg" alt="Imagen 1">
                                                </div>

                                                <div class="check-image-container">
                                                    <asp:CheckBox runat="server" ID="CheckBox8"  name="CheckBox8"/>
                                                    <img src="Resources/dual.jpg" alt="Imagen 1">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Button ID="nextButtonPage4" name="next" CssClass="next action-button" Text="Siguiente" runat="server" OnClick="nextButtonPage4_Click" />
                                    <asp:Button ID="previusButtonPage4" runat="server" name="previous" class="previous action-button-previous" Text="Volver" OnClick="previusButtonPage4_Click" />
                                </fieldset>
                            </asp:View>

                            <!-- PAGINA 5 -->
                            <asp:View runat="server" ID="view5">
                                <fieldset>
                                    <div class="form-card">
                                        <div class="row">
                                            <div class="col-7">
                                                <h2 class="fs-title">Determinar la Trocha</h2>
                                            </div>
                                            <div class="col-5">
                                                <h2 class="steps">Paso 5 - 6</h2>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="descripcion pb-3">
                                            Se define como la distancia que separa los apoyos de las llantas, del lado izquierdo al derecho. Una medida aproximada, es medir de “mita de cubierta a mitad de cubierta”.
                                        </div>
                                        <br />
                                        <img src="Resources/trocha.jpg" alt="Imagen 1" class="img-carga">
                                        <br />
                                        <label runat="server" id="lblErrorTrocha" style="color: red;"></label>
                                        <asp:TextBox runat="server" ID="txtTrochaDelEje" placeholder="Trocha del eje:" CssClass="form-control" />
                                    </div>
                                    <asp:Button ID="nextButtonPage5" name="next" CssClass="next action-button" Text="Siguiente" runat="server" OnClick="nextButtonPage5_Click" />
                                    <asp:Button ID="previusButtonPage5" runat="server" name="previous" class="previous action-button-previous" Text="Volver" OnClick="previusButtonPage5_Click" />
                                </fieldset>
                            </asp:View>

                            <!-- PAGINA 6 -->
                            <asp:View runat="server" ID="view6">
                                <fieldset>
                                    <div class="form-card">
                                        <div class="row">
                                            <div class="col-7">
                                                <h2 class="fs-title">Redacte aquí si tiene algún dato adicional</h2>
                                            </div>
                                            <div class="col-5">
                                                <h2 class="steps">Paso 6 - 6</h2>
                                            </div>
                                        </div>
                                        <br>
                                        <br>
                                        <asp:TextBox runat="server" ID="additionalData" CssClass="textarea form-control rounded" Rows="4" Columns="50" TextMode="MultiLine" placeholder="Escriba aquí..."></asp:TextBox>
                                    </div>
                                    <asp:Button ID="nextButtonPage6" name="next" CssClass="next action-button" Text="Enviar" runat="server" OnClick="nextButtonPage6_Click" />
                                    <asp:Button ID="previusButtonPage6" runat="server" name="previous" class="previous action-button-previous" Text="Volver" OnClick="previusButtonPage6_Click" />
                                </fieldset>
                            </asp:View>

                            <!-- PAGINA 7 -->
                            <asp:View runat="server" ID="view7">
                                <fieldset>
                                    <div class="form-card">
                                        <div class="row">
                                            <div class="col-7">
                                                <h2 class="fs-title">Finalizado:</h2>
                                            </div>
                                            <div class="col-5">
                                                <h2 class="steps">FIN</h2>
                                            </div>
                                        </div>
                                        <br>
                                        <h2 class="purple-text text-center"><strong>SUCCESS !</strong></h2>
                                        <br>
                                        <div class="row justify-content-center">
                                            <div class="col-3">
                                                <img src="Resources/img.png" class="fit-image">
                                            </div>
                                        </div>
                                        <br>
                                        <div class="row justify-content-center">
                                            <div class="col-7 text-center">
                                                <h5 class="purple-text text-center">Su pedido ha sido realizado en menos de 24 horas. Nos comunicaremos con usted.</h5>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row justify-content-center">
                                            <div class="text-center">
                                                <asp:Button ID="btnFinish" name="next" CssClass="next action-button" Text="Finalizar" runat="server" OnClick="btnFinish_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </asp:View>
                        </asp:MultiView>

                    </form>
                </div>
            </div>
        </div>
    </div>
    <!-- partial -->
    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js'></script>
    <script src="Js/script.js"></script>
</body>
</html>
