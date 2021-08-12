# Key Generator

Generates unique keys that can be validated without a lookup table.


### Requirements
- Keys must consist of 8 characters.
- Keys must only consist characters from the set of "ACDEFGHKLMNPRTXYZ234579".
- There will be 10,000,000 unique keys
- Should not be easily guessable.

### Notes
- There are 23 characters available per index. Since we have 8 chars total this makes it 8*23=184 bits (23 bytes) of information. 
- Since there will be 10 million keys our seed size should be big enough to cover it, so at least 24 bits (2^24 = 16,777,216 = 3 Bytes)
- To validate the keys without a lookup all the information should be inside the key so we need a checksum. 
- I haven't chosen to do partial key validation because my assumption is that our validation code is in our control and not on client side. There shouldn't be any risk of reverse engineering our validation logic. If it is on client side partial key validation would have made more sense.
- Below are two ways to generate a unique seed;
  - A seed could be picked from all possible seed list and then that seed is removed from the list so we can never pick the same seed again. This doesn't have good performance but it is always unique. But it could be brute forced since we can't generate big enough seed this way.
  - We could increase the seed size and reduce the chance of collision. Collision chance for a 64 bit value in 10 million generation is ≈0.00000271. It is small enough to ignore so we can pick 8 bytes as our seed size.

 ### Structure

8 bytes seed
8 bytes key is generated using the provided seed.
7 bytes checksum then calculated on operating on both seed and key part.

| Seed    | Key     | Checksum |
| ------- | ------- | -------- |
| 8 Bytes | 8 Bytes | 7 Bytes  |


### References

- [Implementing a Partial Serial Number Verification System in Delphi](https://www.brandonstaggs.com/2007/07/26/implementing-a-partial-serial-number-verification-system-in-delphi/)
- [Generating License Keys in 2021](https://build-system.fman.io/generating-license-keys)
- [Hash Collision Probabilities](https://preshing.com/20110504/hash-collision-probabilities/)

