Module Program
    Sub Main()
        ShowMenu
        
        Console.Write("Press any key to continue . . . ")
        Console.ReadKey(True)
    End Sub
    
    Sub ShowMenu()
        ' Responsive header (i.e. it'll be the width of the window)
        Dim HR As String = ""
        For i = 0 To Console.WindowWidth - 2
            HR &= "#"
        Next i
        Console.WriteLine(HR)
        
        Dim headerText = My.Application.Info.AssemblyName & " v" & My.Application.Info.Version.ToString
        Dim headerSpacing As String = ""
        For i = 0 To (Console.WindowWidth - headerText.Length)\2 -4
            headerSpacing &= " "
        Next
        
        Dim header = "##" & headerSpacing & " " & headerText
        If Console.WindowWidth Mod 2 <> 0 Then header &= " " ' check if odd width
        header &= headerSpacing & "##"
        Console.WriteLine(header)
        
        Console.WriteLine(HR)
        
        
    End Sub
    
    Sub Download(URL As String, Optional OutputFile As String = Nothing)
        If OutputFile <> Nothing Then
            Shell("wget " & URL & " -O " & OutputFile, AppWinStyle.NormalNoFocus, True, -1)
        Else
            Shell("wget " & URL, AppWinStyle.NormalNoFocus, True, -1)
        End If
    End Sub
End Module
