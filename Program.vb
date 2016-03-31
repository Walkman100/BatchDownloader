Module Program
    Dim urlFilePath As String = ""
    Dim filenameFilePath As String = ""
    Dim namePrefix As String = ""
    Dim nameSuffix As String = ""
    
    Sub Main()
        Console.Title = My.Application.Info.AssemblyName & " v" & My.Application.Info.Version.ToString
        
        Do Until False
            ShowMenu()
            Console.Write("Enter choice: ")
            Dim answer = Console.ReadLine
            Select Case answer.ToLower
                Case "cd" ' Change Current Directory
                    Console.Write("Enter path to change to: ")
                    Try
                        Environment.CurrentDirectory = Console.ReadLine
                        Console.Write("Current directory changed to " & Environment.CurrentDirectory & ". ")
                    Catch ex As Exception
                        Console.Writeline(ex.ToString)
                    End Try
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
                Case "ec" ' Set the input encoding used
                    Console.WriteLine("0: Default (""The OS's current ANSI code page."")")
                    Console.WriteLine("1: ASCII")
                    Console.WriteLine("2: Unicode")
                    Console.WriteLine("3: Unicode Big Endian")
                    Console.WriteLine("4: UTF7")
                    Console.WriteLine("5: UTF8")
                    Console.WriteLine("6: UTC32")
                    
                    Console.Write("Enter a number for an encoding: ")
                    answer = Console.ReadKey().Key.ToString
                    Console.WriteLine
                    Try
                      Select Case answer
                        Case "D0"
                            Console.InputEncoding = Text.Encoding.Default
                        Case "D1"
                            Console.InputEncoding = Text.Encoding.ASCII
                        Case "D2"
                            Console.InputEncoding = Text.Encoding.Unicode
                        Case "D3"
                            Console.InputEncoding = Text.Encoding.BigEndianUnicode
                        Case "D4"
                            Console.InputEncoding = Text.Encoding.UTF7
                        Case "D5"
                            Console.InputEncoding = Text.Encoding.UTF8
                        Case "D6"
                            Console.InputEncoding = Text.Encoding.UTF32
                        Case Else
                            Console.Write("""" & answer & """ isn't a valid selection. ")
                            Pause
                      End Select
                    Catch ex As Exception
                        Console.WriteLine(ex.ToString)
                        Pause
                    End Try
                Case "cr" ' Set cursor options
                    Console.WriteLine("1: Set cursor top position")
                    Console.WriteLine("2: Set cursor left position")
                    Console.WriteLine("3: Set cursor size")
                    Console.WriteLine("4: Toggle cursor visibility")
                    
                    Console.Write("Enter a number: ")
                    answer = Console.ReadKey().Key.ToString
                    Console.WriteLine
                    
                    Select Case answer
                        Case "D1"
                            Console.Write("Enter new cursor top position: ")
                            answer = Console.ReadLine
                            Try
                                Console.CursorTop = Convert.ToInt32(answer)
                            Catch ex As Exception
                                Console.Writeline(ex.ToString)
                                Pause
                            End Try
                        Case "D2"
                            Console.Write("Enter new cursor left position: ")
                            answer = Console.ReadLine
                            Try
                                Console.CursorLeft = Convert.ToInt32(answer)
                            Catch ex As Exception
                                Console.Writeline(ex.ToString)
                                Pause
                            End Try
                        Case "D3"
                            Console.Write("Enter new cursor size (percentage): ")
                            answer = Console.ReadLine
                            Try
                                Console.CursorSize = Convert.ToInt32(answer)
                            Catch ex As Exception
                                Console.Writeline(ex.ToString)
                                Pause
                            End Try
                        Case "D4"
                            Console.CursorVisible = Not Console.CursorVisible
                        Case Else
                            Console.Write("""" & answer & """ isn't a valid selection. ")
                            Pause
                    End Select
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
                        Console.Writeline("Currently using: """ & namePrefix & """.")
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
                        Console.Writeline("Currently using: """ & nameSuffix & """.")
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
                Case "dl"
                    Console.WriteLine("Current Directory: " & Environment.CurrentDirectory)
                    Console.WriteLine("Reading URLs from: " & IIf(urlFilePath = "", "STDIN", urlFilePath).ToString)
                    Console.WriteLine("Reading filenames from: " & IIf(filenameFilePath = "", "None, using filename from server", filenameFilePath).ToString)
                    Console.WriteLine("Using filename prefix: " & namePrefix)
                    Console.WriteLine("Using filename suffix: " & nameSuffix)
                    
                    Console.Write(vbNewLine & "To continue, press Enter. Press any other key to go back.")
                    If Console.ReadKey().Key = ConsoleKey.Enter Then
                        Console.WriteLine
                        
                        Dim count As Integer = 1
                        Dim filenames As String()
                        If filenameFilePath <> "" Then filenames = IO.File.ReadAllLines(filenameFilePath)
                        For Each line In IO.File.ReadAllLines(urlFilePath)
                            If filenameFilePath = "" And namePrefix = "" And nameSuffix = "" Then
                                Download(line)
                            ElseIf filenameFilePath = ""
                                Download(line, String.Format(namePrefix, count.ToString) & String.Format(nameSuffix, count.ToString))
                            Else
                                Download(line, String.Format(namePrefix, count.ToString) & filenames(count-1) & String.Format(nameSuffix, count.ToString))
                            End If
                            count += 1
                        Next
                        Console.Write("Download job complete! ")
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
        CalcSpacingAndOutput("Current Directory: " & Environment.CurrentDirectory, False)
        CalcSpacingAndOutput("Current Input Encoding: " & Console.InputEncoding.ToString, False)
        CalcSpacingAndOutput("Window Position: top:" & Console.WindowTop & " left:" & Console.WindowLeft, False)
        CalcSpacingAndOutput("Window Size: width:" & Console.WindowWidth & " height:" & Console.WindowHeight)
        CalcSpacingAndOutput("Buffer Size: width:" & Console.BufferWidth & " height:" & Console.BufferHeight, False)
        CalcSpacingAndOutput("Cursor: top:" & Console.CursorTop & " left:" & Console.CursorLeft & " size:" & Console.CursorSize & "% visible:" & Console.CursorVisible, False)
        
        Console.WriteLine(HR)
        
        'menu algorithm
        Dim arrayToVisualise() As String = {"[CD] Change Current Directory" & vbTab & vbTab & vbTab, "[GV] Get an Environment variable" & vbTab & vbTab, "[EV] Set an Environment variable" & vbTab & vbTab,
            "[ST] Set the window title" & vbTab & vbTab & vbTab, "[EC] Set the input encoding used" & vbTab & vbTab, "[CR] Set cursor options" & vbTab & vbTab & vbTab & vbTab,
            "[WP] Set the window position" & vbTab & vbTab & vbTab, "[WS] Set the window size" & vbTab & vbTab & vbTab, "[BS] Set the buffer size" & vbTab & vbTab & vbTab,
            "Download Settings:" & vbTab & vbTab & vbTab & vbTab, "[UF] Set a file to read URLs from" & vbTab & vbTab, "[NF] Set a file to read filenames from" & vbTab & vbTab,
            "[NP] Set a name Prefix to use" & vbTab, "[NS] Set a name Suffix to use" & vbTab, "[DL] Start Download process" & vbTab, "[EXIT, Q, D] Exit" & vbTab}
        
        Dim selections As String = ""
        Dim columns As Integer = 1
        columns = Console.WindowWidth \ 44
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
            Shell("wget """ & URL & """ -O """ & OutputFile & """", AppWinStyle.NormalNoFocus, True, -1)
        Else
            Shell("wget """ & URL & """", AppWinStyle.NormalNoFocus, True, -1)
        End If
    End Sub
End Module
