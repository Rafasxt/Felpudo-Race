# 🏁 FELPUDO’S RACE: O RESGATE DA FOFURA

**FELPUDO’S RACE** é um **jogo 2D de ação e sobrevivência** em que você controla **Felpudo**, um pássaro destemido em busca de sua amada **Fofura**, sequestrada pelo terrível **Uruca**.  
Desvie de armadilhas, fuja de inimigos e colete frutas mágicas para sobreviver até o grande reencontro.  
Consegue aguentar **2 minutos de caos e emoção**?

---

## 🎮 COMO JOGAR

| Ação | Tecla |
|------|-------|
| **Pular** | `ESPAÇO` |
| **Reiniciar (opcional)** | `R` |
| **Voltar ao menu (opcional)** | `ESC` |

---

## 🍓 OBJETIVO DO JOGO

🏃‍♂️ **Sobreviva por 120 segundos** — essa é a chave da vitória!  
💀 **Evite os inimigos** — tocar neles reduz seu escudo e depois sua vida.  
🍌 **Colete bananas** — ganhe um impulso temporário de velocidade!  
🍉 **Pegue melancias** — recupere vida ou escudo.  
❤️ **Administre suas 3 vidas e 3 escudos** com cuidado.  
🎯 **Felpudo não para** — o mundo inteiro corre com ele!

---

## 🕹️ MECÂNICAS PRINCIPAIS

### ⚔️ Inimigos
- **Barris** — caem do céu e podem te esmagar se você hesitar.  
- **Lesmas** — rastejam velozes da direita para a esquerda.  
- Ambos são mortais se colidirem com Felpudo.

### 🍌 Frutas Especiais
- **Banana** → acelera todo o cenário e inimigos por alguns segundos.  
- **Melancia** → restaura escudo ou vida, conforme a necessidade.  

### 💥 Física e Movimento
- O jogador só pula, mas o cenário e os inimigos se movem dinamicamente, criando o ritmo frenético do jogo.  
- Efeito **parallax** dá profundidade à corrida e imersão visual.

---

## ❤️ CENA FINAL

> Quando o tempo chega a zero, o caos termina e o amor vence.  
> Felpudo e Fofura caminham até o centro da tela, se encontram e…  
> 💕 **Uma chuva de corações** cobre a tela enquanto surge:  
> **“VOCÊ VENCEU!”**

---

## 🖼️ CAPTURA DE TELA



---

## ⚙️ CONSTRUÇÃO

| Recurso | Ferramenta |
|----------|-------------|
| **Motor** | Unity 2021+ |
| **Linguagem** | C# |
| **Plataformas** | PC / WebGL (Play.Unity) |
| **Estilo Visual** | 2D Cartoon com camadas de Parallax |
| **Input System** | Legacy (clássico) |

---

## 💡 DICAS DE SOBREVIVÊNCIA

🔥 **Mantenha o ritmo!** — parar é o mesmo que perder.  
⚡ **Use as frutas com sabedoria.** — a banana acelera o tempo, mas também os perigos!  
🧠 **Observe os padrões dos inimigos.** — eles têm ritmo, aprenda e desvie.  
💪 **Equilíbrio é tudo.** — às vezes, o melhor salto é o que você não dá.

---

## 🏆 CONDIÇÃO DE VITÓRIA

⏰ **Sobreviva por 2 minutos inteiros.**  
Simples na teoria…  
Difícil na prática. 😉  

> “Se o amor move montanhas, ele também atravessa os piores barris.”

---

## ⚒️ ESTRUTURA DO PROJETO
Assets/
├── Scripts/
│ ├── PlayerController2D.cs
│ ├── PlayerHealth.cs
│ ├── EnemySpawner.cs
│ ├── SnailSpawner.cs
│ ├── FruitSpawner.cs
│ ├── GameManager.cs
│ └── FinalMeetByAnchors.cs
├── Scenes/
│ ├── Menu.unity
│ ├── SampleScene.unity
│ └── EncontrotFinal.unity
├── Sprites/
└── UI/

---

## 🧩 ESTRUTURA DE CENAS

| Cena | Descrição |
|------|------------|
| **Menu** | Tela inicial com o botão *Play* |
| **SampleScene** | Fase principal de sobrevivência |
| **EncontroFinal** | Cena final de Felpudo e Fofura |

---

## 👤 AUTORES

**Desenvolvido por:**  
🎨 Rafael Girardi  
💻 Orientação: Prof. Murilo — UNEB (Jogos Digitais)  
📆 2025

> Feito com ☕ café, 🎧 música e ❤️ paixão por jogos 2D.

---

## 📜 LICENÇA

Este projeto é de código aberto sob a **Licença MIT**.  
Você pode usar, modificar e distribuir livremente, desde que mantenha os créditos.

---
