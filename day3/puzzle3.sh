#!/bin/bash

one_bits=( 0 0 0 0 0 0 0 0 0 0 0 0 )
zero_bits=( 0 0 0 0 0 0 0 0 0 0 0 0 )

while read p; do
  for (( i=0; i<${#p}; i++ )); do
    if [[ ${p:$i:1} -eq 1 ]]
    then
      (( one_bits[i]++ ))
    else
      (( zero_bits[i]++ ))
    fi
  done
done

printf "1: %3d %3d %3d %3d %3d %3d %3d %3d %3d %3d %3d %3d\n" ${one_bits[0]} ${one_bits[1]} ${one_bits[2]} ${one_bits[3]} ${one_bits[4]} ${one_bits[5]} ${one_bits[6]} ${one_bits[7]} ${one_bits[8]} ${one_bits[9]} ${one_bits[10]} ${one_bits[11]}

printf "0: %3d %3d %3d %3d %3d %3d %3d %3d %3d %3d %3d %3d\n" ${zero_bits[0]} ${zero_bits[1]} ${zero_bits[2]} ${zero_bits[3]} ${zero_bits[4]} ${zero_bits[5]} ${zero_bits[6]} ${zero_bits[7]} ${zero_bits[8]} ${zero_bits[9]} ${zero_bits[10]} ${zero_bits[11]}
