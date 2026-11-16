# App Hotel · Serra Clara

Simulador de hospedagem desenvolvido por **Samuel** em **2026** para a Agenda 13 de Desenvolvimento de Sistemas II da ETEC. O layout adapta o App Hotel da aula a um hotel fictício na Serra da Mantiqueira.

## Como executar

Abra `AppHotel.slnx` no Visual Studio com o SDK do .NET 11 e a carga de trabalho **Desenvolvimento de interface do usuário de aplicativos multiplataforma .NET**. Selecione **Windows Machine** ou um dispositivo ou emulador **Android** e pressione **F5**.

Para executar no Windows pelo terminal, rode o comando abaixo na pasta da solução.

```powershell
dotnet build AppHotel/AppHotel.csproj -t:Run -f net11.0-windows10.0.19041.0 -p:TargetFrameworks=net11.0-windows10.0.19041.0
```

Para executar no Android, inicie um emulador ou conecte um dispositivo com a depuração USB habilitada.

```powershell
dotnet build AppHotel/AppHotel.csproj -t:Run -f net11.0-android -p:TargetFrameworks=net11.0-android
```

## Como usar

1. Ajuste a quantidade de adultos e crianças usando os controles **Stepper**.
2. Escolha uma suíte no **Picker** e selecione o check-in e o check-out nos **DatePicker**.
3. Use **Calcular estadia** para conferir os hóspedes, as datas, as diárias e o total. O valor é a tarifa da suíte multiplicada pelo número de noites.
4. Use **Editar estadia** para voltar ao formulário com as escolhas preenchidas. A tela **Sobre** fica no cabeçalho do formulário.

O XAML usa `BindingContext` para vincular os controles a `EstadiaViewModel`. A tela de resumo recebe um objeto `ResumoEstadia` como seu próprio contexto.

## Referências

- [Código de referência da Agenda 13](https://github.com/tiagotas/MauiAppHotel/tree/f4651e5172dedfceec4630538ffe4bf340bce128)
- [Aula App Hotel — Parte 1](https://www.youtube.com/watch?v=DvFpB63U8TI)
- [Data Binding com MVVM e XAML — Microsoft Learn](https://learn.microsoft.com/en-us/shows/dotnet-maui-for-beginners/dotnet-maui-data-binding-with-mvvm-xaml-5-of-8-dotnet-maui-for-beginners)
- A fonte DM Serif Text está sob a [SIL Open Font License](AppHotel/OFL-DMSerifText.txt).

A [imagem de capa](AppHotel/Resources/Images/hotel_serra.jpg) foi gerada pela ferramenta integrada de geração de imagens.

<details>
<summary>Prompt da imagem de capa</summary>

> Photorealistic editorial travel photograph for the hero of a Brazilian boutique hotel stay calculator. Wide landscape aspect 3:2. Quiet Serra da Mantiqueira mountain retreat at late afternoon, a warm timber and natural fieldstone lodge with softly lit windows on the right, landscaped native grasses and a small dark reflecting pool in the foreground, layered lush forested Brazilian mountains behind, soft warm sunlight and a calm atmospheric haze. Beautiful authentic Brazilian architecture, elegant but understated. Balanced composition and strong central landscape so the photo can crop into a portrait on desktop and a wide strip on mobile. Natural colors, deep forest green and golden warmth. No text, people, lettering, logo or watermarks.

</details>
