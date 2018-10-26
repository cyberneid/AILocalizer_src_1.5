unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Xml.xmldom, Xml.XMLIntf, Vcl.StdCtrls,
  Xml.XMLDoc, ComObj, MSXML;

type
  TForm1 = class(TForm)
    XMLDocument1: TXMLDocument;
    Button1: TButton;
    Memo1: TMemo;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
    procedure ListValues(const FileName: string; Strings: TStrings);
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
const arquivo = 'D:\Nubia-Z17-mini\Traducao\chinesa\'+
      'NX569J_TRANSLATE_CHINESE\Settings\res\values\strings.xml';

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
var
  xml: IXMLDOMDocument;
  node: IXMLDomNode;
  nodes_row, nodes_se: IXMLDomNodeList;

  i, j: Integer;
  url: string;
begin
  ListValues(arquivo, Memo1.Lines);

end;

procedure TForm1.ListValues(const FileName: string; Strings: TStrings);
var
  I, J: Integer;
  Document: IXMLDOMDocument;
  AttributeNode: IXMLDOMNode;
  ReportSubnodes: IXMLDOMNodeList;
  OperationNodes: IXMLDOMNodeList;
  ParameterNodes: IXMLDOMNodeList;
begin
  Document := CoDOMDocument.Create;
  if Assigned(Document) and Document.load(FileName) then
  begin
    // select all direct child nodes of the redlineaudit/report/ node
    ReportSubnodes := Document.selectSingleNode('resources').childNodes;
    // check if the redlineaudit/report/ node was found and if so, then...
    if Assigned(ReportSubnodes) then
    begin
      // lock the output string list for update
      Strings.BeginUpdate;
      try
        // iterate all direct children of the redlineaudit/report/ node
        for I := 0 to ReportSubnodes.length - 1 do
        begin
          // try to find the "index" attribute of the iterated child node
          AttributeNode := ReportSubnodes[I].attributes.item[0];
          // and if the "index" attribute is found, add a line to the list
          if Assigned(AttributeNode) then
          begin
            Strings.Add(Format('%s index = %s', [AttributeNode.nodeValue, ReportSubnodes[I].text]));

          // select all "operation" child nodes of the iterated child node
          end;
        end;
      finally
        // unlock the output string list for update
        Strings.EndUpdate;
      end;
    end;
  end;
end;

end.
