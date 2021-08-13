# Key Generator

Generates unique keys that can be validated without a lookup table.


### Requirements
- Keys must consist of 8 characters.
- Keys must only consist characters from the set of "ACDEFGHKLMNPRTXYZ234579".
- There will be 10,000,000 unique keys
- Should not be easily guessable.

### Notes
- There are 23 characters available per index. Since we have 8 chars total this makes it 23^8 = 78,310,985,281 possible states. Which is ≈36 bits.
- Since there will be 10 million keys our seed size should be big enough to cover it, so at least 24 bits (2^24 = 16,777,216 = 3 Bytes)
- To validate the keys without a lookup all the information should be inside the key so we need a checksum. 
- I haven't chosen to do partial key validation because my assumption is that our validation code is in our control and not on client side. There shouldn't be any risk of reverse engineering our validation logic. If it is on client side partial key validation would have made more sense. Also we don't have enough space.
- Below are two ways to generate a unique seed;
  - A seed could be picked from all possible seed list and then that seed is removed from the list so we can never pick the same seed again. This doesn't have good performance but it is always unique.
  - We could increase the seed size and reduce the chance of collision. Maximum seed size we can shoose is 32 bits (leaving 4 bits for checksum, which is not good). Collision chance for a 32 bit value in 10 million generation is almost guaranteed. So I have chosen the first approach.
- To make it more resistant to brute force attacks, seed values are salted with a private key.
- To convert the byte array to a valid code we transform it to base 23 (length of characters available).


 ### Structure

| Seed    | Checksum |
| ------- | -------- |
| 24 Bits | 12 Bits  |

### Problems
- Currently randomly generated keys sometimes passes validation stage. ~2000 of 10,000,000 generated keys validated as true despite being generated randomly. I couldn't figure out a way to solve it without increasing the size.
- Since keys are generated from all possible combinations pool, some letters are not used as much in the seed generation. Last 3 digits usually have less occurence first characters of the seed. I don't know how but this probably could be abused

### References

- [Implementing a Partial Serial Number Verification System in Delphi](https://www.brandonstaggs.com/2007/07/26/implementing-a-partial-serial-number-verification-system-in-delphi/)
- [Hash Collision Probabilities](https://preshing.com/20110504/hash-collision-probabilities/)