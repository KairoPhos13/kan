<p align="center">
  <img width="320" alt="kan! logo" src="assets/lazer.png">
</p>

# kan! game client

This repository is the game client of **kan!**, a free rhythm game you play
on a real instrument. It is a fork of [osu!lazer](https://github.com/ppy/osu)
by ppy and its contributors, used under the MIT licence.

**Looking for kan! itself?** The game, its own game mode, the level editor,
the audio engine and the build live in
[KairoPhos13/kan-rhythm](https://github.com/KairoPhos13/kan-rhythm). This
repository is pulled in there as the `game/client` submodule, and it is not
meant to be built or played on its own.

## What is different from osu!lazer

The changes are kept small on purpose, so that upstream improvements can keep
flowing in. Most are hooks that let the kan! game mode add its screens. The
rest give the client kan!'s name and look, and point its online services at
kan!'s own server instead of osu!'s. Every change is listed, with its reason,
in [fork-divergence.md](https://github.com/KairoPhos13/kan-rhythm/blob/main/game/docs/fork-divergence.md).

Code adapted from upstream keeps its `osu.Game.*` namespaces and its licence
headers. New kan! code lives in the kan-rhythm repository.

## Branches

- `main`: kan!'s client, the branch kan-rhythm pins.
- Upstream changes come from `ppy/osu` `master`, merged when kan! updates its
  base.

## Building

Build it through kan-rhythm, which builds this client together with the kan!
game mode:

```shell
git clone --recurse-submodules https://github.com/KairoPhos13/kan-rhythm
cd kan-rhythm/game
make run
```

Requirements and platform notes are in kan-rhythm's
[game/docs/environment.md](https://github.com/KairoPhos13/kan-rhythm/blob/main/game/docs/environment.md).

## Reporting problems

Please report kan! problems in
[kan-rhythm's issues](https://github.com/KairoPhos13/kan-rhythm/issues), never
to ppy/osu. The osu! team does not maintain kan! and should not receive its
bug reports.

## Credits and licence

kan! stands on the work of [ppy](https://github.com/ppy) and the osu!lazer
contributors. Thank you.

The code is licensed under the MIT licence: see [LICENCE](LICENCE) and
[THIRD_PARTY_NOTICES.md](THIRD_PARTY_NOTICES.md). Game resources from
[ppy/osu-resources](https://github.com/ppy/osu-resources) that the client
still loads are covered by their own licence.

"osu!" and its logo are trademarks of ppy Pty Ltd. kan! is an independent
project, not affiliated with or endorsed by ppy or osu!.
