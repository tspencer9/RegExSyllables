<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegexSyllables.aspx.cs" Inherits="RegExSyllables.RegexSyllables" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Regex Syllables Program</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container-fluid">
        <div class="jumbotron">
            <h1 class="h1">Finding syllables with regular expressions</h1>
            <p>This is a program that determines reading level using the Flesch-Kincaid formula</p>
        </div>
        <form id="syllablesForm" runat="server">
            <div>
                <h3>Enter some text below:</h3>
                <asp:TextBox ID="phraseTextBox" runat="server" BorderStyle="Inset" Columns="100" Rows="10" TextMode="MultiLine"></asp:TextBox><br />
                <br />
                <asp:Button ID="PhraseSubmitButton" runat="server" Text="Submit" OnClick="PhraseSubmitButton_Click" />
            </div>
            <div>
                <br />
                <h3>Reading level results:</h3>
                <table class="table-primary">
                    <tr>
                        <td>
                            <asp:Label ID="SentenceLabel" runat="server" Text="Sentences:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="SentenceTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="WordLabel" runat="server" Text="Words:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="WordTextbox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="SyllableLabel" runat="server" Text="Syllables:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="SyllableTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="ScoreLabel" runat="server" Text="Score:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="ScoreTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LevelLabel" runat="server" Text="Reading level:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="LevelTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </div>
    <script src="http://code.jquery.com/jquery.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
