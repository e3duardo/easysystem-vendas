using System.Collections.Generic;
using System.Text;
using System;
using Library.Converter;
using System.Windows.Forms;

namespace Library.Classes
{
    public class Print
    {
        //notas:::
        static public void PrintCondicional(Library.Condicional orcamento)
        {
            try
            {
                MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

                MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

                _Reporter.Output = "LPT1";

                _Reporter.StartJob();

                _Reporter.PrintText(01, 14, _EpsonCodes.ExpandedOn + "ARTE LIVRE" + _EpsonCodes.ExpandedOff);
                _Reporter.PrintText(02, 06, _EpsonCodes.ItalicOn + _Reporter.CleanText("Rua Governador Roberto Silveira, 755") + _EpsonCodes.ItalicOff);
                _Reporter.PrintText(03, 17, "(22) 3852-1606");
                _Reporter.PrintText(04, 16, _EpsonCodes.CondensedOn + _EpsonCodes.ExpandedOn + _Reporter.CleanText("Condicional") + _EpsonCodes.ExpandedOff + _EpsonCodes.CondensedOff);

                _Reporter.PrintText(06, 01, "");
                _Reporter.PrintText(07, 02, _Reporter.CleanText("N.: " + orcamento.Id));
                _Reporter.PrintText(08, 01, DateTime.Now.ToShortDateString());
                _Reporter.PrintText(08, 43, DateTime.Now.ToShortTimeString());

                _Reporter.PrintText(09, 01, "-----------------------------------------------");

                List<Library.CondicionalProduto> orcamentoProdutos = Library.CondicionalProdutoBD.FindAdvanced(new Library.Classes.QItem("o.id", orcamento.Id));

                int i = 0;
                foreach (Library.CondicionalProduto op in orcamentoProdutos)
                {
                    _Reporter.PrintText(10 + i, 02, op.Quantidade.ToString());
                    _Reporter.PrintText(10 + i, 08, _Reporter.CleanText(op.Produto.Nome));
                    string preco = op.PrecoTotal.Value.ConvertToMoneyString();
                    _Reporter.PrintText(10 + i, 47 - preco.Length, preco);
                    i++;
                }

                string tota = orcamento.Valor.ConvertToMoneyString();

                _Reporter.PrintText(11 + i, 25, "TOTAl: ");
                _Reporter.PrintText(11 + i, 47 - tota.Length, tota);

                _Reporter.EndJob();
                _Reporter.PrintJob();

                PrintCliente(orcamento.Cliente);

                Library.Classes.Print.PrintSpace();


            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        static public void PrintVenda(Library.Venda venda)
        {
            try
            {
                MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

                MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

                _Reporter.Output = "LPT1";

                _Reporter.StartJob();

                _Reporter.PrintText(01, 14, _EpsonCodes.ExpandedOn + "ARTE LIVRE" + _EpsonCodes.ExpandedOff);
                _Reporter.PrintText(02, 06, _EpsonCodes.ItalicOn + _Reporter.CleanText("Rua Governador Roberto Silveira, 755") + _EpsonCodes.ItalicOff);
                _Reporter.PrintText(03, 17, "(22) 3852-1606");
                _Reporter.PrintText(04, 19, _EpsonCodes.CondensedOn + _EpsonCodes.ExpandedOn + _Reporter.CleanText("Venda") + _EpsonCodes.ExpandedOff + _EpsonCodes.CondensedOff);

                _Reporter.PrintText(06, 01, "");
                _Reporter.PrintText(07, 02, _Reporter.CleanText("N.: " + venda.Id));
                _Reporter.PrintText(08, 02, DateTime.Now.ToString("dd/MM/yyyy"));
                _Reporter.PrintText(08, 42, DateTime.Now.ToShortTimeString());

                _Reporter.PrintText(09, 01, "-----------------------------------------------");

                List<Library.VendaProduto> vendaProdutos = Library.VendaProdutoBD.FindAdvanced(new Library.Classes.QItem("v.id", venda.Id));

                decimal produtostotal = 0;
                int i = 0;
                foreach (Library.VendaProduto vp in vendaProdutos)
                {
                    _Reporter.PrintText(10 + i, 02, vp.Quantidade.ToString());
                    _Reporter.PrintText(10 + i, 08, _Reporter.CleanText(vp.Produto.Nome));

                    string preco = vp.PrecoTotal.Value.ConvertToMoneyString();

                    _Reporter.PrintText(10 + i, 47 - preco.Length, preco);
                    produtostotal += vp.PrecoTotal.Value;
                    i++;
                }

                if (venda.FormaPagamento == "avista")
                {
                    string tota = produtostotal.ConvertToMoneyString();
                    string tdea = venda.Valor.ConvertToMoneyString();

                    _Reporter.PrintText(11 + i, 25, "TOTAl: ");
                    _Reporter.PrintText(11 + i, 47 - tota.Length, tota);

                    _Reporter.PrintText(12 + i, 19, "TOTAl FINAL: ");
                    _Reporter.PrintText(12 + i, 47 - tdea.Length, tdea);

                    _Reporter.PrintText(13 + i, 01, "");
                }
                else if (venda.FormaPagamento == "aprazo")
                {
                    string tot = venda.Valor.ConvertToMoneyString();
                    _Reporter.PrintText(11 + i, 25, "TOTAl: ");
                    _Reporter.PrintText(11 + i, 47 - tot.Length, tot);

                    _Reporter.PrintText(12 + i, 01, "");
                    _Reporter.PrintText(13 + i, 01, "-----------------------------------------------");

                    _Reporter.PrintText(14 + i, 02, "Entrada");
                    string entrada = venda.Entrada.ConvertToMoneyString();
                    _Reporter.PrintText(14 + i, 47 - entrada.Length, entrada);

                    decimal j = 1;
                    foreach (Library.VendaParcela vp in Library.VendaParcelaBD.FindAdvanced(new QItem("v.id", venda.Id)))
                    {
                        _Reporter.PrintText(15 + i, 02, "Parcela " + j + " " + vp.Data.Value.ToString("dd/MM/yyyy"));

                        string preco = vp.Valor.Value.ConvertToMoneyString();
                        _Reporter.PrintText(15 + i, 47 - preco.Length, preco);
                        i++;
                        j++;
                    }

                    _Reporter.PrintText(16 + i, 01, "-----------------------------------------------");
                }
                else
                {
                    string tot = venda.Valor.ConvertToMoneyString();
                    _Reporter.PrintText(11 + i, 25, "TOTAl: ");
                    _Reporter.PrintText(11 + i, 47 - tot.Length, tot);

                    _Reporter.PrintText(12 + i, 01, "");
                }



                _Reporter.EndJob();

                _Reporter.PrintJob();


                if (venda.FormaPagamento == "avista")
                {
                    Library.Classes.Print.PrintPagamentoAVista();
                }
                else if (venda.FormaPagamento == "aprazo")
                {
                    Library.Classes.Print.PrintPagamentoAPrazo();
                    PrintCliente(venda.Cliente);
                }
                else if (venda.FormaPagamento == "cartao")
                {
                    Library.Classes.Print.PrintPagamentoCartao();
                }
                else if (venda.FormaPagamento == "cheque")
                {
                    Library.Classes.Print.PrintPagamentoCheque();
                }
                Library.Classes.Print.PrintSpace();


            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        static public void PrintCaixa(Library.Caixa caixa)
        {
            try
            {
                decimal vendaavista = 0;
                decimal vendaaprazo = 0;
                decimal despesas = 0;
                decimal outrasOperacoes = 0;

                List<Library.CaixaTransacao> transacoes = Library.CaixaTransacaoBD.FindAdvanced(new QItem("ct.idCaixa", caixa.Id));

                foreach (Library.CaixaTransacao ct in transacoes)
                {
                    if (ct.Despesa != null)
                        despesas += ct.Valor;
                    else if (ct.Venda != null)
                    {
                        if (ct.VendaParcela == null)
                            vendaavista += ct.Valor;
                        else
                            vendaaprazo += ct.Valor;
                    }
                    else
                        outrasOperacoes += ct.Valor;
                }


                MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

                MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

                _Reporter.Output = "LPT1";

                _Reporter.StartJob();


                int i = 1;
                _Reporter.PrintText(i, 01, _Reporter.CleanText("CAIXA " + caixa.Data.Value.ToShortDateString()));
                i++;
                _Reporter.PrintText(i, 01, " ");
                i++;
                if (vendaavista > 0)
                {
                    _Reporter.PrintText(i, 01, _Reporter.CleanText("Vendas a vista: "));
                    string valor1 = vendaavista.ConvertToMoneyString();
                    _Reporter.PrintText(i, 47 - valor1.Length, valor1);
                    i++;
                }
                if (vendaaprazo > 0)
                {
                    _Reporter.PrintText(i, 01, _Reporter.CleanText("Vendas a prazo: "));
                    string valor1 = vendaaprazo.ConvertToMoneyString();
                    _Reporter.PrintText(i, 47 - valor1.Length, valor1);
                    i++;
                }
                if (despesas > 0)
                {
                    _Reporter.PrintText(i, 01, _Reporter.CleanText("Despesas: "));
                    string valor1 = despesas.ConvertToMoneyString();
                    _Reporter.PrintText(i, 47 - valor1.Length, valor1);
                    i++;
                }
                if (outrasOperacoes > 0)
                {
                    _Reporter.PrintText(i, 01, _Reporter.CleanText("Outras operacoes: "));
                    string valor1 = outrasOperacoes.ConvertToMoneyString();
                    _Reporter.PrintText(i, 47 - valor1.Length, valor1);
                    i++;
                }
                _Reporter.PrintText(i, 01, " ");
                i++;
                _Reporter.PrintText(i, 01, _Reporter.CleanText("TOTAL: "));
                string valor = caixa.Saldo.ConvertToMoneyString();
                _Reporter.PrintText(i, 47 - valor.Length, valor);
                i++;


                _Reporter.EndJob();

                Console.WriteLine(_Reporter.PreviewJob());
                //_Reporter.PrintJob();

                //PrintSpace();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
        }

        //compartilhadas:::
        static public void PrintSpace()
        {
            MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

            MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

            _Reporter.Output = "LPT1";

            _Reporter.StartJob();

            _Reporter.PrintText(01, 01, "");
            _Reporter.PrintText(02, 01, "");
            _Reporter.PrintText(03, 01, "");
            _Reporter.PrintText(04, 01, "");
            _Reporter.PrintText(05, 01, "");
            _Reporter.PrintText(06, 01, "");
            _Reporter.PrintText(07, 01, "");

            _Reporter.EndJob();

            _Reporter.PrintJob();
        }

        static public void PrintCliente(Library.Cliente cliente)
        {
            MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

            MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

            _Reporter.Output = "LPT1";

            _Reporter.StartJob();

            _Reporter.PrintText(01, 01, "");

            int i = 2;

            _Reporter.PrintText(i, 02, _Reporter.CleanText(cliente.Nome));
            i++;

            if (cliente.Cpf != "")
            {
                _Reporter.PrintText(i, 02, "CPF: " + _Reporter.CleanText(cliente.Cpf));
                i++;
            }
            if (cliente.Endereco != "")
            {
                _Reporter.PrintText(i, 02, _Reporter.CleanText(cliente.Endereco));
                i++;
            }
            if (cliente.Cidade != "")
            {
                _Reporter.PrintText(i, 02, _Reporter.CleanText(cliente.Cidade));
                _Reporter.PrintText(i, cliente.Cidade.Length, _Reporter.CleanText("-" + cliente.Estado));
                i++;
            }
            _Reporter.PrintText(i, 01, "");
            i++;
            _Reporter.PrintText(i, 01, "");
            i++;
            _Reporter.PrintText(i, 01, "-----------------------------------------------");
            i++;
            _Reporter.PrintText(i, 19, "ASSINATURA");
            i++;
            _Reporter.PrintText(i, 01, "");

            _Reporter.EndJob();

            _Reporter.PrintJob();
        }

        static public void PrintPagamentoAVista()
        {
            MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

            MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

            _Reporter.Output = "LPT1";

            _Reporter.StartJob();

            _Reporter.PrintText(01, 02, _Reporter.CleanText("Pagamento a vista"));
            _Reporter.PrintText(02, 02, "Volte Sempre!");

            _Reporter.EndJob();

            _Reporter.PrintJob();
        }
        static public void PrintPagamentoAPrazo()
        {
            MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

            MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

            _Reporter.Output = "LPT1";

            _Reporter.StartJob();

            _Reporter.PrintText(01, 02, _Reporter.CleanText("Pagamento a prazo"));
            _Reporter.PrintText(02, 02, "Volte Sempre!");

            _Reporter.EndJob();

            _Reporter.PrintJob();
        }
        static public void PrintPagamentoCheque()
        {
            MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

            MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

            _Reporter.Output = "LPT1";

            _Reporter.StartJob();

            _Reporter.PrintText(01, 02, _Reporter.CleanText("Pagamento em cheque"));
            _Reporter.PrintText(02, 02, "Volte Sempre!");

            _Reporter.EndJob();

            _Reporter.PrintJob();
        }
        static public void PrintPagamentoCartao()
        {
            MatrixReporter.EpsonCodes _EpsonCodes = new MatrixReporter.EpsonCodes();

            MatrixReporter.Reporter _Reporter = new MatrixReporter.Reporter();

            _Reporter.Output = "LPT1";

            _Reporter.StartJob();

            _Reporter.PrintText(01, 02, _Reporter.CleanText("Pagamento em cartão"));
            _Reporter.PrintText(02, 02, "Volte Sempre!");

            _Reporter.EndJob();

            _Reporter.PrintJob();
        }

        //antigas:::
        static public string GeneratorStringVendaQuitarParcela(Library.Venda venda)
        {
            List<Library.VendaProduto> vendaProdutos = Library.VendaProdutoBD.FindAdvanced(new QItem("v.id", venda.Id));


            StringBuilder sb = new StringBuilder();

            sb.Append(GeneratorHead());


            sb.Append("\n");

            sb.Append("\n");

            sb.Append(" VENDA: ");
            sb.Append(venda.Id);
            sb.Append("\n");

            sb.Append("----------------------------------------\n");

            sb.AppendFormat("{0,40}", venda.Data);
            sb.Append("\n");

            sb.Append("\n");

            if (vendaProdutos.Count >= 1)
                sb.Append(GeneratorProdutos(vendaProdutos));


            return sb.ToString();
        }
        static public string GeneratorHead()
        {
            Library.Classes.StringFunctions sf = new Library.Classes.StringFunctions();

            StringBuilder sb = new StringBuilder();

            sb.Append("               CENTERCAR                \n");
            sb.Append("      ----------------------------      \n");
            sb.Append("          AV NILO PEÇANHA, XXX          \n");
            sb.Append("            (22) 3852-XXXX              \n");
            //sb.Append("----------------------------------------\n");

            return sb.ToString();
        }
        static public string GeneratorProdutos(List<Library.VendaProduto> vendaProdutos)
        {
            Library.Classes.StringFunctions sf = new Library.Classes.StringFunctions();

            /*StringBuilder sb = new StringBuilder();

            sb.Append(sf.CSP("QTD", 10, 'e') + sf.CSP("DESCRICAO", 30, 'e') + sf.CSP("VALOR", 10, 'd') + "\n");
            sb.Append(sf.MS("", 50, "d", '-') + "\n");
            foreach (Library.VendaProduto vp in vendaProdutos)
            {
                sb.Append(sf.CSP(vp.Quantidade.ToString(), 10, 'e') + sf.CSP(vp.Produto.Nome, 30, 'e') + sf.CSP(f.ConvertDecimalToMoneyString(vp.PrecoTotal), 10, 'd') + "\n");
            }
            sb.Append("\n");
            sb.Append(sf.MS("", 50, "d", '-') + "\n");
            sb.Append(sf.MS("TOTAL: ", 7, "e", ' ') + sf.MS(f.ConvertDecimalToMoneyString(venda.Valor), 43, "d", ' ') + "\n");
            sb.Append(sf.MS("", 50, "d", '-') + "\n");*/

            StringBuilder sb = new StringBuilder(200);

            //sb.Append("  QTD  DESCRICAO                 VALOR  \n");

            //sb.Append("----------------------------------------\n");

            foreach (Library.VendaProduto vp in vendaProdutos)
            {
                sb.Append(' ', 2);
                sb.AppendFormat("{0:000}", vp.Quantidade);
                sb.Append(' ', 2);
                sb.AppendFormat("{0,-21}", sf.CS(vp.Produto.Nome, 21));
                sb.Append(' ', 2);
                sb.AppendFormat("{0,8}", vp.PrecoTotal.Value.ToString("F2"));
                sb.Append(' ', 2);
                sb.Append('\n');
            }

            //sb.Append("----------------------------------------\n");
            sb.Append('\n');

            sb.Append("     TOTAL:  ");
            sb.AppendFormat("{0,25}", vendaProdutos[0].Venda.Valor.ToString("F2"));
            sb.Append(' ', 2);
            sb.Append('\n');

            //sb.Append("----------------------------------------\n");


            //rtbcupom.Text += (cupom.ToString());

            return sb.ToString();
        }
    }
}
