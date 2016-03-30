﻿Module Program
    Dim urlFilePath, filenameFilePath, namePrefix, nameSuffix As String
    
    Sub Main()
        Console.Title = My.Application.Info.AssemblyName & " v" & My.Application.Info.Version.ToString
        
        Do Until False
            ShowMenu()
            Console.Write("Enter choice: ")
            Dim answer = Console.ReadLine
            Select Case answer.ToLower
                Case "cd" ' Change Current Directory
                    Console.Write("Enter path to change to: ")
                    Environment.CurrentDirectory = Console.ReadLine
                    Console.Write("Current directory changed to " & Environment.CurrentDirectory & ". ")
                    Pause
                Case "gv" ' Get an Environment variable
                    Console.Write("Enter environment variable to get: ")
                    answer = Console.ReadLine
                    Console.Write("Contents of environment variable """ & answer & """ is """ & Environment.GetEnvironmentVariable(answer) & """. ")
                    Pause
                Case "ev" ' Set an Environment variable
                    Console.Write("Enter environment variable to set: ")
                    answer = Console.ReadLine
                    Console.Writeline("Current contents: """ & Environment.GetEnvironmentVariable(answer) & """. Enter new contents:")
                    Environment.SetEnvironmentVariable(answer, Console.ReadLine)
                    Console.Write("Environment variable """ & answer & """ set to """ & Environment.GetEnvironmentVariable(answer) & """. ")
                    Pause
                Case "st" ' Set the window title
                    Console.Write("Enter new title: ")
                    Console.Title = Console.ReadLine
                Case "ec" ' Set the encoding used
'                    Console.Write("Enter environment variable to get: ")
'                    answer = Console.ReadLine
'                    Console.Write("Contents of environment variable """ & answer & """ is """ & Environment.GetEnvironmentVariable(answer) & """. Press any key to continue... ")
'                    Console.ReadKey(True)
                Case "cr" ' Set cursor options
'                    Console.Write("Enter environment variable to get: ")
'                    answer = Console.ReadLine
'                    Console.Write("Contents of environment variable """ & answer & """ is """ & Environment.GetEnvironmentVariable(answer) & """. Press any key to continue... ")
'                    Console.ReadKey(True)
                Case "wp" ' Set the window position
                    Console.Write("Enter new window top position: ")
                    answer = Console.ReadLine
                    Try
                        Console.WindowTop = Convert.ToInt32(answer)
                    Catch ex As Exception
                        Console.Writeline(ex.ToString)
                    End Try
                    Console.Write("Enter new window left position: ")
                    answer = Console.ReadLine
                    Try
                        Console.WindowLeft = Convert.ToInt32(answer)
                    Catch ex As Exception
                        Console.Writeline(ex.ToString)
                        Pause
                    End Try
                Case "ws" ' Set the window size
                    Console.Write("Enter new window width: ")
                    answer = Console.ReadLine
                    Try
                        Console.WindowWidth = Convert.ToInt32(answer)
                    Catch ex As Exception
                        Console.Writeline(ex.ToString)
                    End Try
                    Console.Write("Enter new window height: ")
                    answer = Console.ReadLine
                    Try
                        Console.WindowHeight = Convert.ToInt32(answer)
                    Catch ex As Exception
                        Console.Writeline(ex.ToString)
                        Pause
                    End Try
                Case "bs" ' Set the buffer size
                    Console.Write("Enter new buffer width: ")
                    answer = Console.ReadLine
                    Try
                        Console.BufferWidth = Convert.ToInt32(answer)
                    Catch ex As Exception
                        Console.Writeline(ex.ToString)
                    End Try
                    Console.Write("Enter new buffer height: ")
                    answer = Console.ReadLine
                    Try
                        Console.BufferHeight = Convert.ToInt32(answer)
                    Catch ex As Exception
                        Console.Writeline(ex.ToString)
                        Pause
                    End Try
                Case "uf" ' Set a file to read URLs from
                    If urlFilePath <> "" Then
                        Console.Writeline("Currently reading from: """ & urlFilePath & """.")
                    End If
                    Console.Write("Enter file path to read URLs to download from: ")
                    answer = Console.ReadLine
                    If IO.File.Exists(answer) Then
                        urlFilePath = answer
                        Console.Write("Reading URLs from """ & urlFilePath & """. ")
                    Else
                        Console.Write("File """ & answer & """ doesn't exist! ")
                    End If
                    Pause
                Case "nf" ' Set a file to read filenames from
                    If filenameFilePath <> "" Then
                        Console.Writeline("Currently reading from: """ & filenameFilePath & """.")
                    End If
                    Console.Write("Enter file path to read filenames to download to: ")
                    answer = Console.ReadLine
                    If IO.File.Exists(answer) Then
                        filenameFilePath = answer
                        Console.Write("Reading filenames from """ & filenameFilePath & """. ")
                    Else
                        Console.Write("File """ & answer & """ doesn't exist! ")
                    End If
                    Pause
                Case "np" ' Set a name Prefix to use
                    If namePrefix <> "" Then
                        Console.Writeline("Currently reading from: """ & namePrefix & """.")
                    End If
                    Console.Write("Enter text to prepend to filenames (use {0} to specify the current number file): ")
                    answer = Console.ReadLine
                    If answer <> "" Then
                        namePrefix = answer
                        Console.Write("Filename prefix set to """ & namePrefix & """. ")
                    Else
                        Console.Write("Filename prefix not changed! ")
                    End If
                    Pause
                Case "ns" ' Set a name Suffix to use
                    If nameSuffix <> "" Then
                        Console.Writeline("Currently reading from: """ & nameSuffix & """.")
                    End If
                    Console.Write("Enter text to append to filenames (use {0} to specify the current number file): ")
                    answer = Console.ReadLine
                    If answer <> "" Then
                        nameSuffix = answer
                        Console.Write("Filename prefix set to """ & nameSuffix & """. ")
                    Else
                        Console.Write("Filename prefix not changed! ")
                    End If
                    Pause
                Case ""
                Case "exit", "q", "d", "♦" ' apparently that's ^D
                    Exit Do
                Case Else
                    Console.WriteLine("Unknown entry " & answer & "!")
                    Pause
            End Select
        Loop
    End Sub
    
    Sub Pause() 'mimicing cmd
        Console.Write("Press any key to continue . . . ")
        Console.ReadKey(True)
        Console.WriteLine()
    End Sub
    
    Sub CalcSpacingAndOutput(centerText As String, Optional normal As Boolean = True)
        Dim spacing As String = ""
        For i = 0 To (Console.WindowWidth - centerText.Length)\2 -4
            spacing &= " "
        Next
        If normal Then
            Console.WriteLine("##" & spacing & " " & centerText & IIf(Console.WindowWidth Mod 2 = 0, "", " ").ToString & spacing & "##")
        Else
            Console.WriteLine("##" & spacing & " " & centerText & IIf(Console.WindowWidth Mod 2 = 0, " ", "").ToString & spacing & "##")
        End If
    End Sub
    
    Sub ShowMenu()
        Console.Clear
        ' Responsive header (i.e. it'll be the width of the window)
        Dim HR As String = ""
        For i = 0 To Console.WindowWidth - 2
            HR &= "#"
        Next i
        Console.WriteLine(HR)
        
        CalcSpacingAndOutput(My.Application.Info.AssemblyName & " v" & My.Application.Info.Version.ToString & " by Walkman100")
        CalcSpacingAndOutput("https://github.com/Walkman100/BatchDownloader", False)
        Console.WriteLine(HR)
        
        CalcSpacingAndOutput("Startup Path: " & My.Application.Info.DirectoryPath, False)
        CalcSpacingAndOutput("Current Directory: " & Environment.CurrentDirectory)
        CalcSpacingAndOutput("Current Encoding: " & Console.OutputEncoding.ToString)
        CalcSpacingAndOutput("Window Position: top:" & Console.WindowTop & " left:" & Console.WindowLeft, False)
        CalcSpacingAndOutput("Window Size: width:" & Console.WindowWidth & " height:" & Console.WindowHeight)
        CalcSpacingAndOutput("Buffer Size: width:" & Console.BufferWidth & " height:" & Console.BufferHeight, False)
        CalcSpacingAndOutput("Cursor: top:" & Console.CursorTop & " left:" & Console.CursorLeft & " size:" & Console.CursorSize & " visible:" & Console.CursorVisible)
        
        Console.WriteLine(HR)
        
        'menu algorithm
        Dim arrayToVisualise() As String = {"[CD] Change Current Directory" & vbTab & vbTab, "[GV] Get an Environment variable" & vbTab, "[EV] Set an Environment variable" & vbTab,
            "[ST] Set the window title" & vbTab & vbTab, "[EC] Set the encoding used" & vbTab & vbTab, "[CR] Set cursor options" & vbTab & vbTab & vbTab,
            "[WP] Set the window position" & vbTab & vbTab, "[WS] Set the window size" & vbTab & vbTab, "[BS] Set the buffer size" & vbTab & vbTab,
            "Download Settings:" & vbTab & vbTab & vbTab & vbTab, "[UF] Set a file to read URLs from" & vbTab & vbTab, "[NF] Set a file to read filenames from" & vbTab & vbTab,
            "[NP] Set a name Prefix to use" & vbTab, "[NS] Set a name Suffix to use" & vbTab, "[EXIT, Q, D] Exit" & vbTab}
        
        Dim selections As String = ""
        Dim columns As Integer = 1
        columns = Console.WindowWidth \ 40
        If arrayToVisualise.Length Mod columns = 0 Then
            For i = 1 To arrayToVisualise.Length \ columns ' i is number of lines
                For j = 1 To columns ' j is current column
                    selections &= arrayToVisualise( (arrayToVisualise.Length \ columns) * (j-1) +i -1)
                    If j = columns Then selections &= vbNewLine
                Next
            Next
        Else
            For i = 1 To arrayToVisualise.Length \ columns +1 ' i is number of lines
                For j = 1 To columns ' j is current column
                    Try
                        selections &= arrayToVisualise( (arrayToVisualise.Length \ columns +1) * (j-1) +i -1)
                    Catch
                    End Try
                    If j = columns Then selections &= vbNewLine
                Next
            Next
        End If
        Console.WriteLine(selections)
    End Sub
    
    #Region "Menu Algorithm Explanation"
'		j
'1	2	3	4	5 (`columns`)
'2
'3
'4
'5
'6
'7
'
'i
'
'array(i-1)
'array.length = how many there are
'
'for i = 1 to length \ columns [amount in each column]
'    for j = 1 to columns
'        add array( (length \ columns [amount in each column] * j-1 [get current tens amount]) +i [current count] -1 [to get index])
'    next
'next
'
'
'for i = 1 to length \ columns +1 [amount in each column, one more for unevenness]
'    for j = 1 to columns
'        add array( (length \ columns +1 [see above] * j-1 [get current tens amount]) +i [current count] -1 [to get index])
'    next
'next
#End Region
    
    Sub Download(URL As String, Optional OutputFile As String = Nothing)
        If OutputFile <> Nothing Then
            Shell("wget " & URL & " -O " & OutputFile, AppWinStyle.NormalNoFocus, True, -1)
        Else
            Shell("wget " & URL, AppWinStyle.NormalNoFocus, True, -1)
        End If
    End Sub
End Module
