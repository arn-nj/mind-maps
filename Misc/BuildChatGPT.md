# Building GPT from Scratch in Code

## Introduction
- **ChatGPT** is an AI system designed for text-based interactions.
- It generates responses probabilistically, meaning the same input can yield different outputs.
- **This session covers:**
  - What a **language model** is and how it works.
  - The **Transformer architecture** behind GPT.
  - Step-by-step implementation of a small **GPT-like model**.

## Understanding Language Models

### What is a Language Model?
- **Definition:** A model that predicts the next word (or token) in a sequence based on context.
- **Example:**
  - Input: "I love to eat"
  - Model prediction: "pizza" (based on learned patterns)
- **Types of Language Models:**
  - **Character-level models** (predict next character)
  - **Word-level models** (predict next word)
  - **Subword/token-level models** (used in GPT)

### The Evolution of Language Models
- **Early models:** Used statistical methods like n-grams.
- **RNNs & LSTMs:** Allowed handling of longer dependencies but suffered from vanishing gradients.
- **Transformers (2017):** Introduced in "Attention Is All You Need" paper, overcoming previous limitations.
- **GPT (Generative Pre-trained Transformer):** A Transformer-based model designed for text generation.

## The Transformer Architecture

### Key Components of Transformers
1. **Tokenization & Embeddings**
   - Converts text into numerical representations.
   - **Types:** Character-level, word-level, and subword-level tokenization.
   - **Example:** "Hello" → `[104, 101, 108, 108, 111]`

2. **Self-Attention Mechanism**
   - Allows words to focus on relevant parts of a sentence.
   - Uses **Query (Q), Key (K), and Value (V)** matrices.
   - **Example:** "Paris is the capital of France" → "Paris" attends to "France".

3. **Multi-Head Attention**
   - Applies multiple attention heads in parallel.
   - Captures different types of word relationships.
   - **Example:** One head might focus on subject-verb relationships, another on adjectives.

4. **Feed-Forward Layers**
   - After attention, words are processed through a neural network.
   - Enhances the model's ability to detect patterns.

5. **Positional Encoding**
   - Adds information about word order, as transformers lack inherent sequential understanding.
   - Uses sine and cosine functions to represent position.

## Implementing GPT from Scratch

### Step 1: Setting Up the Dataset
- Use **Tiny Shakespeare Dataset** (1MB of Shakespeare's works in text form).
- Convert text into **tokens** using character-level tokenization.
- Create **train-validation split** (90% training, 10% validation).

### Step 2: Creating a Simple Neural Network
- **Initial model:** A basic neural network predicting characters.
- **Steps:**
  - Convert characters into numerical IDs.
  - Map IDs to embeddings.
  - Pass through a simple linear layer.
- **Limitation:** No context awareness beyond single characters.

### Step 3: Implementing Self-Attention
- **Goal:** Allow model to analyze relationships between different words.
- **Steps:**
  1. Compute **Q, K, V** matrices from input embeddings.
  2. Compute attention scores using `Q * K^T / sqrt(d_k)`.
  3. Apply **softmax** to get probability distribution.
  4. Multiply by **V** to obtain weighted representations.
- **Matrix Trick:** Use efficient matrix multiplication to speed up attention calculations.

### Step 4: Adding Multi-Head Attention
- Instead of one attention mechanism, apply **multiple in parallel**.
- Each head learns different linguistic properties.
- Concatenate results from all heads before passing to the feed-forward network.

### Step 5: Training the Model
- Use **PyTorch** for training.
- **Optimization:** Adam optimizer with learning rate tuning.
- **Loss function:** Cross-entropy loss for next-character prediction.
- **Training strategy:**
  - Feed input text chunks into the model.
  - Predict next tokens.
  - Compute and backpropagate loss.

## Generating Text with GPT
- Start with a **seed text** (e.g., "To be or not to be")
- Generate new characters sequentially.
- **Temperature scaling:** Controls randomness of output.
  - **Low temperature:** Conservative, repetitive output.
  - **High temperature:** More diverse, sometimes nonsensical output.

## Summary
- **GPT is built using Transformers** with self-attention and multi-head attention.
- **Self-attention enables understanding of long-range word dependencies.**
- **Training requires massive datasets and compute power.**
- **Fine-tuning on specific tasks improves performance.**

## ELI5 (Explain Like I'm 5)
- Imagine you’re writing a story with a super-intelligent assistant.
- You start a sentence: "Once upon a time..."
- The assistant predicts what might come next based on everything it has read before.
- It doesn’t just look at the last word, but at all the words in the sentence.
- This is how **GPT** works—it predicts text **based on patterns it has learned** from tons of books and articles.
