Imports System.Data.SqlClient


Public Class Cadastro
    Private conexao As SqlConnection
    Private comando As SqlCommand
    Private da As SqlDataAdapter
    Private dr As SqlDataReader
    Private strSQL As String


    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click


        Try

            conexao = New SqlConnection("Server=TL026;Database=BANCO DE TESTE;User Id=sa;Password=111@senha;
")
            strSQL = " INSERT INTO CAD_CLIENTE (NOME, NUMERO, ENDERECO, EMAIL) VALUES (@NOME, @NUMERO, @ENDERECO, @EMAIL)"

            comando = New SqlCommand(strSQL, conexao)
            comando.Parameters.AddWithValue("@NOME", txtNome.Text)
            comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text)
            comando.Parameters.AddWithValue("@ENDERECO", txtEndereco.Text)
            comando.Parameters.AddWithValue("@EMAIL", txtEmail.Text)

            conexao.Open()
            comando.ExecuteNonQuery()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexao.Close()
            comando.Clone()
            comando = Nothing
            conexao = Nothing

        End Try


    End Sub

    Private Sub btnExibir_Click(sender As Object, e As EventArgs) Handles btnExibir.Click


        Try

            conexao = New SqlConnection("Server=nomedoserver;Database=bomedobanco DE TESTE;User Id=sa;Password=senhabanco;")
            strSQL = "SELECT * FROM CAD_CLIENTE"

            comando = New SqlCommand(strSQL, conexao)
            da = New SqlDataAdapter(strSQL, conexao)
            Dim ds As New DataSet
            da.Fill(ds)

            dgvDados.DataSource = ds.Tables(0)
            conexao.Open()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexao.Close()
            comando.Clone()
            comando = Nothing
            conexao = Nothing

        End Try
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try

            conexao = New SqlConnection("Server=nomedoserver;Database=bomedobanco DE TESTE;User Id=sa;Password=senhabanco;")
            strSQL = "SELECT * FROM CAD_CLIENTE WHERE ID = @ID"

            comando = New SqlCommand(strSQL, conexao)
            comando.Parameters.AddWithValue("@ID", txtID.Text)
            conexao.Open()

            dr = comando.ExecuteReader

            Do While dr.Read
                txtNome.Text = dr("nome")
                txtNumero.Text = dr("numero")
                txtEndereco.Text = dr("endereco")
                txtEmail.Text = dr("email")

            Loop


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexao.Close()
            comando.Clone()
            comando = Nothing
            conexao = Nothing
            dr = Nothing

        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try

            conexao = New SqlConnection("Server=nomedoserver;Database=bomedobanco DE TESTE;User Id=sa;Password=senhabanco;")
            strSQL = " UPDATE CAD_CLIENTE SET NOME = @NOME, NUMERO = @NUMERO, ENDERECO = @ENDERECO, EMAIL = @EMAIL WHERE ID = @ID"

            comando = New SqlCommand(strSQL, conexao)
            comando.Parameters.AddWithValue("@ID", txtID.Text)
            comando.Parameters.AddWithValue("@NOME", txtNome.Text)
            comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text)
            comando.Parameters.AddWithValue("@ENDERECO", txtEndereco.Text)
            comando.Parameters.AddWithValue("@EMAIL", txtEmail.Text)

            conexao.Open()
            comando.ExecuteNonQuery()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexao.Close()
            comando.Clone()
            comando = Nothing
            conexao = Nothing

        End Try
    End Sub

    Private Sub BtnExcluir_Click(sender As Object, e As EventArgs) Handles BtnExcluir.Click
        Try

            conexao = New SqlConnection("Server=nomedoserver;Database=bomedobanco DE TESTE;User Id=sa;Password=senhabanco;")
            strSQL = " DELETE CAD_CLIENTE WHERE ID = @ID"

            comando = New SqlCommand(strSQL, conexao)
            comando.Parameters.AddWithValue("@ID", txtID.Text)


            conexao.Open()
            comando.ExecuteNonQuery()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexao.Close()
            comando.Clone()
            comando = Nothing
            conexao = Nothing

        End Try
    End Sub
End Class


