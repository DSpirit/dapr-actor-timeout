#!/bin/bash
seq 1 100 | xargs -n 1 -P 100 curl "http://localhost:5000/api/timeout/get"