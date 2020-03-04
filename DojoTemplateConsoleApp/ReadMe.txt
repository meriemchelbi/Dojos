# Code Dojo - Let's Get Profiling!

Let's start making our 'deliberate practice' a little more _deliberate_.

_Many_ people regularly commit code without profiling it. While this might be OK for smaller scale apps. At the scale we have, there can be many, many easy wins to be had in terms of performance - but we're unsure where we can look.

"Shift left" isn't just about reducing 'bugs' to live - it's about improving _quality_ to live. Performance is a subset of quality.
**The sooner we improve the performance of our code, the better.**

... and there's no better time than when you're writing it!

> **It's _highly_ recommended you pair/mob program with other humans for this.**

---

### A simple problem...

You've a friend that really hates losing!

Every time you play a game where a coin toss might be required - they always asks for the next "best of `X`" (e.g. you flip two heads, winning best of `3` - they then want to go to `5`").

You decide to implement a coin-flipping program that will give best of `101` coin flips.

This program **must**:

1. Return a string of 'flip' results as `H` and `T` characters (in a single line). This helps convince your friend you're not cheating 😅
2. Return "Heads/Tails Wins!" with appropriate winner.

Example:

```shell
> coinflip
HHHTTHHH ... (snipped for brevity)
Heads Wins!
```

---

## 🟢 First stage...

> ⚠ _It's highly recommended to **commit early, commit often** during this Dojo. Especially when trying new ideas._

1. Implement code to meet the requirements (or copy-🍝 some starting code below).
2. Run the code through a profiler (more information below) - how can you improve it's performance? **Take note of:**
   * Your hypotheses for improvements.
   * Are there going to be any trade-offs between each?
3. Now, actually implent your different hypotheses! Once you're done - **re-profile the code, taking note of:**
   * Did your hypotheses play out as expected?
   * Did your hypotheses stack well/at all?
   * Where there additional trade-offs you hadn't expected?

> ℹ **Unsure where to start with a profiler? Check out the links below:**
> *  **.NET:** [Visual Studio](https://docs.microsoft.com/en-us/visualstudio/profiling/?view=vs-2019), ReSharper ([dotTrace](https://www.jetbrains.com/profiler/)).
> * **JavaScript:** [Node.js / Chrome DevTools](https://medium.com/@paul_irish/debugging-node-js-nightlies-with-chrome-devtools-7c4a1b95ae27)

---

## 🛑 Discuss!...

Now, discuss and consider the following with your pair/group:

* How much better was your optimised code compared to your starting code.
* Does your readability suffer as you progress towards higher performance? 
* We've optimised for `101` coinflips - what if we parameterised the number? What problems do you forsee?
* Consider if this code was running in the cloud - how could you optimise for more CPU/memory?
* Could we optimise to use some extra cores?

---

## 🟢 Second stage...

Your friend is now convinced that you need _more_ coinflips - no matter how much you try and explain probabilities to them. However, they are not sure how many flips they want.

Therefore, **you need to update the program so that you can define the number of flips to take place.**

The program must now _also:_

* Accept the number of coinflips to make - this must be a positive, even integer value.


### Profiling against parameters

Now, re-profile your code with the following number of coinflips:

1. `101` (Baseline)
2. `10,000` Large value.
3. `10,000,000` Getting kind of silly now. 🤪

Now consider:

1. How does the program perform against different workloads?
2. How can you optimise for higher workloads?
3. How can you ensure you use an optimal algorithm given the input?

---

## Starting code

> **It's highly recommended that you write your own starting code** - the problem is intentionally short-to-solve. The comparison of your 'default' code versus 'optimised' code is a key part of the conversation.

If you're wanting to get started with profiling quickly - here's some sample code.

### C#

```c#
public static class CoinFlipper
    {
        public static (string results, string winner) Flip()
        {
            var rng = new Random();
            var results = new List<char>();

            for (int i = 0; i < 101; i++)
            {
                results.Add(rng.Next(1, 2) == 1 ? 'H' : 'T');
            }

            var winner = results.Count(x => x == 'H') > 50 ? "Heads" : "Tails";

            return (string.Join("", results), $"{winner} Wins!");
        }
    }
```

### JavaScript

```js
function flip()
{
    var results = [];

    for (var i = 0; i < 101; i++)
    {
        results.push((Math.random() * 11 <= 5) ?'H' : 'T');
    }

    var winner = results.filter(x => x == 'H').length > 50 ? "Heads" : "Tails";

    return {
        'results': results.join(''),
        'winner': `${winner} Wins!`
    };
}
```

---

## Lastly...

Head over to [#culture-of-craft](https://trainline.slack.com/archives/C72DMJWR0) on Slack and **[share your code](https://slack.com/intl/en-gb/slack-tips/share-code-snippets)!**. Add the `#lets-get-profiling` tag to the post so we can find them.

When sharing, consider adding comments on things like:

* Things that unexpectedly did/didn't work.
* Difficulties/challenges faced.
* Other ideas you wanted to try but didn't have the time.

Also - **get involved with other people's code snippets!**

* Add some Emoji responses! For example:
    * 😍 Love the way the code looks.
    * ⭐ Best practice(s).
    * 🤯 Impressive, innovative code.
    * 🥇 Your favourite.
    * ⚡ Fast!
    * ⌨ Lean/little typing required.

* Share comments/ideas on how they can improve.
* Give praise for things you like/learned.

> **Have fun and enjoy the Dojo!**